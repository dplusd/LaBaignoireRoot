var jsonParagraphs = null;
var lines = null;
function processStory(json) {
    var story = JSON.parse(json);
    lines = story.Lines;
    var paragraphs = story.Paragraphs
    mainDiv = document.getElementById("contentDiv");
    for (i = 0 ; i < paragraphs.length ; ++i) {
        newP = document.createElement("P")
        var Text = "";
        for (ln = paragraphs[i]._StartLine ; ln < paragraphs[i]._EndLine ; ++ln)
            Text += lines[ln] + "<br>"
        newP.innerHTML = Text;
        if (i == 0) {

            paragraphs[i].defaultClass = "header"
            paragraphs[i].selectedClass = "headerSelected"
        }
        else {
            paragraphs[i].defaultClass = "par"
            paragraphs[i].selectedClass = "parSelected"
        }

        newP.className = paragraphs[i].defaultClass
        paragraphs[i].domElement = newP;
        mainDiv.appendChild(newP);
    }

    jsonParagraphs = paragraphs;
}
var taatikMap = {};
function processTaatikMap(map) {
    var charMap = JSON.parse(map);
    for (i = 0 ; i < charMap.length ; ++i)
        taatikMap[charMap[i].arabic] = charMap[i].heb;
}
var request = new XMLHttpRequest();

request.open("GET", ScripJsonSource, true);
request.onload = function (e) {
    if (request.readyState === 4) {
        if (request.status === 200) {
            processStory(request.responseText);
        } else {
            console.error(request.statusText);
        }
    }
};
request.onerror = function (e) {
    console.error(request.statusText);
};
request.send(null)
var requestTaatik = new XMLHttpRequest();
requestTaatik.open("GET", TaaticScriptSource, true);
requestTaatik.onload = function (e) {
    if (requestTaatik.readyState === 4) {
        if (requestTaatik.status === 200) {
            processTaatikMap(requestTaatik.responseText);
        } else {
            console.error(requestTaatik.statusText);
        }
    }
};
request.onerror = function (e) {
    console.error(requestTaatik.statusText);
};
requestTaatik.send(null)