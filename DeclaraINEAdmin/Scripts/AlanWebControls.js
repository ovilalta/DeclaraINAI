
$(document).ready(function () {
    clientPaging();
    AlertSucccessFading();
}
    );

function clientPaging() {
    $("table[AllowClientPaging='true']").each(function () {
        var currentPage = 0;
        var numPerPage = 10;
        var $table = $(this);
        $table.bind('repaginate', function () {
            $table.find('tbody tr').hide().slice(currentPage * numPerPage, (currentPage + 1) * numPerPage).show();
        });
        $table.trigger('repaginate');
        var numRows = $table.find('tbody tr').length;
        var numPages = Math.ceil(numRows / numPerPage);
        var $pager = $("<ul class='AlanPager'></ul>");
        for (var page = 0; page < numPages; page++) {
            $('<div></div>').text(page + 1).bind('click', {
                newPage: page
            }, function (event) {
                currentPage = event.data['newPage'];
                $table.trigger('repaginate');
                $(this).addClass('active').siblings().removeClass('active');
            }).appendTo($pager).addClass('clickable');
        }
        var $containedpager = $("<div class='AlanPagerContainer'></div>");
        $pager.appendTo($containedpager);
        $containedpager.insertAfter($table).find('div.clickable:first').addClass('active');
    });
}

function AlertSucccessFading() {
    $("div[alerttype='success']").each(function () {
        $(this).fadeOut(3789);
    });
}

function showMessageBox() {
    $("div[message='box']").each(function () {
        $(this).modal({ backdrop: 'static', keyboard: false });
    });

    //document.oncontextmenu = function () { return false }
    //window.onkeydown = function (event) {
    //    if (event.keyCode == 123) {
    //        return false;
    //    } else if ((event.ctrlKey && event.shiftKey && event.keyCode == 73) || (event.ctrlKey && event.shiftKey && event.keyCode == 74)) {
    //        return false;
    //    }

}

function menuClick() {
    $('.dropdown-submenu a.test').on("click", function (e) {
        $(this).next('ul').toggle();
        e.stopPropagation();
        e.preventDefault();
    });
}