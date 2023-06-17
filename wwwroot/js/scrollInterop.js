window.scrollInterop = {
    saveScrollPosition: function (element) {
        var scrollTop = element ? element.scrollTop : 0;
        window.sessionStorage.setItem('scrollPosition', scrollTop);
    },
    getScrollPosition: function () {
        var scrollPosition = window.sessionStorage.getItem('scrollPosition');
        return scrollPosition ? parseInt(scrollPosition) : 0;
    },
    setScrollPosition: function (element, position) {
        if (element) {
            element.scrollTop = position;
        }
    }
};
