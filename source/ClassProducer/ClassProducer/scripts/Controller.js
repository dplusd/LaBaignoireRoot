var timer = null;
var playState = null;
function audioLoaded() {
    audioHandler = document.getElementById("audioStream");

    audioHandler.play()
    audioHandler.playbackRate = 1;
    setPlayState("play");

}
function startTimer() {
    if (timer != null)
        return;
    timer = window.setInterval(syncText, 500);
}
var audioHandler;
var selectedPar = null;
function syncText() {
    time = audioHandler.currentTime;
    for (var i = 0 ; i < jsonParagraphs.length ; ++i) {
        if (time >= jsonParagraphs[i].StartAudioPos && time < jsonParagraphs[i].EndAudioPos) {

            if (jsonParagraphs[i].domElement.className != jsonParagraphs[i].selectedClass) {
                jsonParagraphs[i].domElement.className = jsonParagraphs[i].selectedClass
                scrollToPar(jsonParagraphs[i].domElement)
                selectedPar = i;
            }
        }
        else if (jsonParagraphs[i].domElement.className != jsonParagraphs[i].defaultClass) {
            jsonParagraphs[i].domElement.className = jsonParagraphs[i].defaultClass;
        }
    }
}
var mode = "arabic"
function toTaatik(text) {
    var retVal = ""
    for (i = 0 ; i < text.length ; ++i) {
        if (taatikMap[text[i]] === undefined)
            retVal += text[i]
        else
            retVal += taatikMap[text[i]]
    }
    return retVal;

}
function switchTatik() {
    if (mode == "arabic") {
        for (j = 0 ; j < jsonParagraphs.length ; ++j) {
            Text = ""
            par = jsonParagraphs[j]

            for (ln = par._StartLine ; ln < par._EndLine ; ++ln) {
                Text += toTaatik(lines[ln]) + "<br>"
            }
            par.domElement.innerHTML = Text;
            document.getElementById("btnTaatik").src = "https://raw.githubusercontent.com/dplusd/LaBaignoireRoot/master/source/ClassProducer/ClassProducer/scripts/arab.png"
        }
        mode = "taatik"
    }
    else if (mode == "taatik") {
        for (j = 0 ; j < jsonParagraphs.length ; ++j) {
            Text = ""
            for (ln = jsonParagraphs[j]._StartLine ; ln < jsonParagraphs[j]._EndLine ; ++ln)
                Text += lines[ln] + "<br>"
            jsonParagraphs[j].domElement.innerHTML = Text;
            document.getElementById("btnTaatik").src = "https://raw.githubusercontent.com/dplusd/LaBaignoireRoot/master/source/ClassProducer/ClassProducer/scripts/taatik.png"
        }
        mode = "arabic"
    }
}
function scrollToPar(par) {
    topPos = par.offsetTop;
    document.getElementById('wrapper').scrollTop = topPos - 200;
}
function setSpeed(change) {
    document.getElementById("audioStream").playbackRate = document.getElementById("audioStream").playbackRate + change;
}

function goToPar(which) {
    if (selectedPar == null)
        return;
    if (selectedPar + which < 0 || selectedPar + which >= jsonParagraphs.length)
        return
    document.getElementById("audioStream").currentTime = jsonParagraphs[selectedPar + which].StartAudioPos;
    document.getElementById("audioStream").play()
    setPlayState("play");    
}

function stop() {
    audioHandler = document.getElementById("audioStream");

    
    if (playState == "play") {
        audioHandler.pause()
        setPlayState("pause");
    }
    else if (playState == "pause") {
        audioHandler.play()
        setPlayState("play");
    }
}

function setPlayState(newPlayState) {
    playState = newPlayState;
    document.getElementById("btStopPause").src = "https://raw.githubusercontent.com/dplusd/LaBaignoireRoot/master/source/ClassProducer/ClassProducer/scripts/" + (playState == "play" ? "pause" : "play") + ".png"
}