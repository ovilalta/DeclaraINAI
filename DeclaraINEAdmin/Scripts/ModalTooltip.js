﻿$(document).ready(function () {
    modalToolTip();
}
);

function modalToolTip () {

    $('.po-markup > .po-link').popover({
        trigger: 'hover',
        html: true,  // must have if HTML is contained in popover

        // get the title and conent
        title: function () {
            return $(this).parent().find('.po-title').html();
        },
        content: function () {
            return $(this).parent().find('.po-body').html();
        },

        container: 'body',
        placement: 'left'

    });
}

