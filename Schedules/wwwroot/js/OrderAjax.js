////const { placements } = require("@popperjs/core");

document.addEventListener('DOMContentLoaded', function () {

    $('#School_select').on('change', GetClientFromSchool);

    function GetClientFromSchool(e) {
        if (typeof (this.value) != 'undefined' && this.value != 0) {
            $.ajax({
                type: "GET",
                url: `/Orders/GetClientFromSchool`,
                data: { "id": parseInt(this.value) },
                success: function (result) {
                    $('#Client_select').selectize()[0].selectize.setValue(result, true);
                    $('#Client_select').off('change', GetSchoolFromClient);
                },
                error: function () {
                }
            });
        }
    }


    $('#Client_select').on('change', GetSchoolFromClient);

    function GetSchoolFromClient(e) {
        if (typeof (this.value) != 'undefined' && this.value != 0) {
            $.ajax({
                type: "GET",
                url: `/Orders/GetSchoolFromClient`,
                data: { "id": parseInt(this.value) },
                success: function (result) {
                    $('#School_select').selectize()[0].selectize.setValue(result, true);
                    $('#School_select').off('change', GetClientFromSchool);
                },
                error: function () {
                }
            });
        }
    }

    $(function () {
        var PlaceHolderElement = $('#PlaceHolder');
        $('button[data-toggle="ajax-modal"]').click(function (event) {
            var url = $(this).data('url');
            if (typeof ($(this).data('id')) != 'undefined') {
                url += "/" + $(this).data('id');
            }
            $.get(url).done(function (data) {
                PlaceHolderElement.html(data);
                PlaceHolderElement.find('.modal').modal('show');
                $('select').selectize();
            });
        });

        PlaceHolderElement.on('click', '[data-save="payment"]', function (event) {
            var form = $(this).parents('.modal').find('form');
            var actionUrl = form.attr('action');
            var sendData = form.serialize();
            $.post(actionUrl, sendData).done(function () {
                PlaceHolderElement.find('.modal').modal('hide');
                location.reload();
            });
        });

        PlaceHolderElement.on('click', '[data-save="client"]', function (event) {
            var form = $(this).parents('.modal').find('form');
            var actionUrl = form.attr('action');
            var sendData = form.serialize();
            $.post(actionUrl, sendData).done(function (result) {
                PlaceHolderElement.find('.modal').modal('hide');
                var data = JSON.parse(result);

                $('#School_select').selectize()[0].selectize.addOption(data['school']);
                $('#Client_select').selectize()[0].selectize.addOption(data['client']);

                $('#School_select').selectize()[0].selectize.setValue(data['school']['value'], true);
                $('#Client_select').selectize()[0].selectize.setValue(data['client']['value'], true);

            });
        });

    });

}, false);


