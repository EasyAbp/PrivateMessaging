$(function () {

    var l = abp.localization.getResource('PrivateMessaging');

    var service = easyAbp.privateMessaging.privateMessages.privateMessage;
    var detailModal = new abp.ModalManager(abp.appPath + 'PrivateMessages/DetailModal');
    var createModal = new abp.ModalManager(abp.appPath + 'PrivateMessages/CreateModal');
    let widgetManager = new abp.WidgetManager("#main-navbar-collapse");

    var dataTable = $('#PrivateMessageTable').DataTable(abp.libs.datatables.normalizeConfiguration({
        bSort: false,
        processing: true,
        serverSide: true,
        paging: true,
        searching: false,
        autoWidth: false,
        scrollCollapse: true,
        ajax: abp.libs.datatables.createAjax(service.getListSent),
        columnDefs: [
            {
                rowAction: {
                    items:
                        [
                            {
                                text: l('Read'),
                                action: function (data) {
                                    detailModal.open({ id: data.record.id });
                                }
                            }
                        ]
                }
            },
            { data: "toUser.userName" },
            { data: "title" },
            { data: "creationTime" },
        ]
    }));
    
    createModal.onResult(function () {
        widgetManager.refresh();
        dataTable.ajax.reload();
    });

    $('#InboxButton').click(function (e) {
        document.location.href = 'Inbox';
    });

    $('#NewPrivateMessageButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });
});