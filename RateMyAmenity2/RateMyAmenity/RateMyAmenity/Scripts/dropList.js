
/* DropList Code: adapted from ‘Show/Hide content with sliding effect’ dhtmlgoodies.com (http://www.dhtmlgoodies.com)*/

var dropList_slideSpeed = 5; // Higher value = faster
var dropList_timer = 15; // Lower value = faster

var objectIdToSlideDown = false;
var dropList_activeId = false;
var dropList_slideInProgress = false;
var dropList_expandMultiple = false; // true = multiple items expanded at the same time.


function showHideContent(e, inputId) {
    if (dropList_slideInProgress) return;
    dropList_slideInProgress = true;
    if (!inputId) inputId = this.id;
    inputId = inputId + '';
    var numericId = inputId.replace(/[^0-9]/g, '');
    var answerDiv = document.getElementById('dropList_a' + numericId);

    objectIdToSlideDown = false;

    if (!answerDiv.style.display || answerDiv.style.display == 'none') {
        if (dropList_activeId && dropList_activeId != numericId && !dropList_expandMultiple) {
            objectIdToSlideDown = numericId;
            slideContent(dropList_activeId, (dropList_slideSpeed * -1));
        } else {

            answerDiv.style.display = 'block';
            answerDiv.style.visibility = 'visible';

            slideContent(numericId, dropList_slideSpeed);
        }
    } else {
        slideContent(numericId, (dropList_slideSpeed * -1));
        dropList_activeId = false;
    }
}

function slideContent(inputId, direction) {

    var obj = document.getElementById('dropList_a' + inputId);
    var contentObj = document.getElementById('dropList_ac' + inputId);
    height = obj.clientHeight;
    if (height == 0) height = obj.offsetHeight;
    height = height + direction;
    rerunFunction = true;
    if (height > contentObj.offsetHeight) {
        height = contentObj.offsetHeight;
        rerunFunction = false;
    }
    if (height <= 1) {
        height = 1;
        rerunFunction = false;
    }

    obj.style.height = height + 'px';
    var topPos = height - contentObj.offsetHeight;
    if (topPos > 0) topPos = 0;
    contentObj.style.top = topPos + 'px';
    if (rerunFunction) {
        setTimeout('slideContent(' + inputId + ',' + direction + ')', dropList_timer);
    } else {
        if (height <= 1) {
            obj.style.display = 'none';
            if (objectIdToSlideDown && objectIdToSlideDown != inputId) {
                document.getElementById('dropList_a' + objectIdToSlideDown).style.display = 'block';
                document.getElementById('dropList_a' + objectIdToSlideDown).style.visibility = 'visible';
                slideContent(objectIdToSlideDown, dropList_slideSpeed);
            } else {
                dropList_slideInProgress = false;
            }
        } else {
            dropList_activeId = inputId;
            dropList_slideInProgress = false;
        }
    }
}



function initShowHideDivs() {
    var divs = document.getElementsByTagName('DIV');
    var divCounter = 1;
    for (var no = 0; no < divs.length; no++) {
        if (divs[no].className == 'dropList_header') {
            divs[no].onclick = showHideContent;
            divs[no].id = 'dropList_q' + divCounter;
            var answer = divs[no].nextSibling;
            while (answer && answer.tagName != 'DIV') {
                answer = answer.nextSibling;
            }
            answer.id = 'dropList_a' + divCounter;
            contentDiv = answer.getElementsByTagName('DIV')[0];
            contentDiv.style.top = 0 - contentDiv.offsetHeight + 'px';
            contentDiv.className = 'dropList_content_content';
            contentDiv.id = 'dropList_ac' + divCounter;
            answer.style.display = 'none';
            answer.style.height = '1px';
            divCounter++;
        }
    }
}
window.onload = initShowHideDivs;