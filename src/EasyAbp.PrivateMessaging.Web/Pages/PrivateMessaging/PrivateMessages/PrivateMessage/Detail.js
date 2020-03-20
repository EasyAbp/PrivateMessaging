$(function () {

    var createModal = new abp.ModalManager(abp.appPath + 'PrivateMessaging/PrivateMessages/PrivateMessage/CreateModal');
    var dataTableElement = $('#PrivateMessageTable');
    var widgetManager = new abp.WidgetManager({filterForm: 'PmNotification'});

    $('#ReplyPrivateMessage').click(function (e) {
        createModal.open({toUserName: $('#PrivateMessage_CreatorUserName').val()});
    });

    createModal.onResult(function () {
        if (widgetManager) widgetManager.refresh();
        if (dataTableElement) dataTableElement.DataTable().ajax.reload();
    });
    
});