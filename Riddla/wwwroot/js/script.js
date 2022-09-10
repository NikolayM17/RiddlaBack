let pressedId = '';

function nav__item_click(elem) {
    pressedId = elem.id;

    let elems = document.getElementsByClassName('nav__item');
    
    for (let index = 0; index < elems.length; index++) {
        elems[index].style.color = 'rgb(180, 180, 180)';
    }

    elem.style.color = 'white';
}

function nav__item_mouseenter(elem) {
    elem.style.color = 'white';
}

function nav__item_mouseleave(elem) {
    if (elem.id != pressedId)
    {
        elem.style.color = 'rgb(180, 180, 180)';
    }
}
