var menuOpener = document.querySelector('.c-sidenav__opener'),
	menu = document.querySelector('.c-sidenav');

menuOpener.addEventListener('click', function() {
	menu.classList.toggle('c-sidenav--is-open');
});

$(document).ready(function () {
    $('.collapsible').collapsible();
});