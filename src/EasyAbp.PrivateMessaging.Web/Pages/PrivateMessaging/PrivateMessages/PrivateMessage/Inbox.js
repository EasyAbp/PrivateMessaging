$(function () {

    var l = abp.localization.getResource('EasyAbpPrivateMessaging');

    var service = easyAbp.privateMessaging.privateMessages.privateMessage;
    var detailModal = new abp.ModalManager(abp.appPath + 'PrivateMessaging/PrivateMessages/PrivateMessage/DetailModal');
    var createModal = new abp.ModalManager(abp.appPath + 'PrivateMessaging/PrivateMessages/PrivateMessage/CreateModal');
    var widgetManager = new abp.WidgetManager({filterForm: 'PmNotification'});

    var dataTable = $('#PrivateMessageTable').DataTable(abp.libs.datatables.normalizeConfiguration({
        bSort: false,
        processing: true,
        serverSide: true,
        paging: true,
        searching: false,
        autoWidth: false,
        scrollCollapse: true,
        ajax: abp.libs.datatables.createAjax(service.getList),
        columnDefs: [
            {
                rowAction: {
                    items:
                        [
                            {
                                text: l('Read'),
                                action: function (data) {
                                    service.setRead([data.record.id])
                                        .then(function () {
                                            detailModal.open({ id: data.record.id });
                                            widgetManager.refresh();
                                            dataTable.ajax.reload();
                                        })
                                }
                            },
                            {
                                text: l('SetRead'),
                                action: function (data) {
                                    service.setRead([data.record.id])
                                        .then(function () {
                                            widgetManager.refresh();
                                            dataTable.ajax.reload();
                                        });
                                }
                            },
                            {
                                text: l('Delete'),
                                confirmMessage: function (data) {
                                    return l('PrivateMessageDeletionConfirmationMessage', data.record.title.substring(0, 10) + '...');
                                },
                                action: function (data) {
                                    service.delete(data.record.id)
                                        .then(function () {
                                            abp.notify.info(l('SuccessfullyDeleted'));
                                            widgetManager.refresh();
                                            dataTable.ajax.reload();
                                        });
                                }
                            }
                        ]
                }
            },
            {
                data: "creator.userName",
                render: function ( data, type, row, meta ) { return renderRow(row, data) }
            },
            {
                data: "title",
                render: function ( data, type, row, meta ) { return renderRow(row, data) }
            },
            {
                data: "creationTime",
                render: function ( data, type, row, meta ) { return renderRow(row, data) }
            }
        ]
    }));

    function renderRow(row, data) {
        return row.readTime == null ? '<span class="bold">' + data + '</span>' : data;
    }
    
    createModal.onResult(function () {
        widgetManager.refresh();
        dataTable.ajax.reload();
    });

    $('#OutboxButton').click(function (e) {
        document.location.href = 'Outbox';
    });

    $('#NewPrivateMessageButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });
});