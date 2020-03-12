$(function () {

    var l = abp.localization.getResource('PrivateMessaging');

    var service = easyAbp.privateMessaging.privateMessages.privateMessage;
    var createModal = new abp.ModalManager(abp.appPath + 'PrivateMessages/PrivateMessage/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'PrivateMessages/PrivateMessage/EditModal');

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
                                text: l('Edit'),
                                action: function (data) {
                                    editModal.open({ id: data.record.id });
                                }
                            },
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
            { data: "tenantId" },
            { data: "toUserId" },
            { data: "title" },
            { data: "content" },
            { data: "readTime" },
        ]
    }));

    createModal.onResult(function () {
        dataTable.ajax.reload();
    });

    editModal.onResult(function () {
        dataTable.ajax.reload();
    });

    $('#NewPrivateMessageButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });
});