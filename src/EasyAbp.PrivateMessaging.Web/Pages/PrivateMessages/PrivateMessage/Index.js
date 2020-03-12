$(function () {

    var l = abp.localization.getResource('PrivateMessaging');

    var service = easyAbp.privateMessaging.privateMessages.privateMessage;
    var createModal = new abp.ModalManager(abp.appPath + 'PrivateMessages/PrivateMessage/CreateModal');

    var dataTable = $('#PrivateMessageTable').DataTable(abp.libs.datatables.normalizeConfiguration({
        processing: true,
        serverSide: true,
        paging: true,
        searching: false,
        autoWidth: false,
        scrollCollapse: true,
        order: [[1, "asc"]],
        ajax: abp.libs.datatables.createAjax(service.getList),
        columnDefs: [
            {
                rowAction: {
                    items:
                        [
                            {
                                text: l('Delete'),
                                confirmMessage: function (data) {
                                    return l('PrivateMessageDeletionConfirmationMessage', data.record.id);
                                },
                                action: function (data) {
                                    service.delete(data.record.id)
                                        .then(function () {
                                            abp.notify.info(l('SuccessfullyDeleted'));
                                            dataTable.ajax.reload();
                                        });
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
        dataTable.ajax.reload();
    });

    $('#NewPrivateMessageButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });
});