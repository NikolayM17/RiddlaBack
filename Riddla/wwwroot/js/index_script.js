function reg_auth_click(elemName) {
    document.querySelector('body').classList.add('frame__style');

    let elems = document.getElementsByClassName(elemName);

    for (let index = 0; index < elems.length; index++) {
        // elems[index].style.opacity = 1;

        elems[index].style.visibility = "visible";
    }
}

function element_closeButton_click(elemName) {
    document.querySelector('body').classList.remove('frame__style');

    let elems = document.getElementsByClassName(elemName);

    for (let index = 0; index < elems.length; index++) {
        // elems[index].style.opacity = 0;
        elems[index].style.visibility = "hidden";
    }
}

function restore_click(elemSenderName) {
    let elems = document.getElementsByClassName(elemSenderName);

    for (let index = 0; index < elems.length; index++) {
        // elems[index].style.opacity = 0;
        elems[index].style.visibility = "hidden";
    }


    elems = document.getElementsByClassName('restore__element');

    for (let index = 0; index < elems.length; index++) {
        // elems[index].style.opacity = 0;
        elems[index].style.visibility = "visible";
    }
}

function viewPassword_click(elemId) {
    let elems = document.getElementById(elemId);

    for (let index = 0; index < elems.length; index++) {
        // elems[index].style.opacity = 0;
        elems[index].style.visibility = "hidden";
    }
}

function reg_auth_navigate(elemFrom, elemTo) {
    let elems = document.getElementsByClassName(elemFrom);

    for (let index = 0; index < elems.length; index++) {
        elems[index].style.visibility = "hidden";
    }

    elems = document.getElementsByClassName(elemTo);

    for (let index = 0; index < elems.length; index++) {
        elems[index].style.visibility = "visible";
    }
}

function passwordView_click(elemId, elemSenderId) {
    let elem = document.getElementById(elemId);
    let elemSender = document.getElementById(elemSenderId);

    if (elem.type == "password") {
        elem.type = "text";

        elemSender.style.opacity = 1;
    }
    else {
        elem.type = "password";

        elemSender.style.opacity = 0.7;
    }
}
