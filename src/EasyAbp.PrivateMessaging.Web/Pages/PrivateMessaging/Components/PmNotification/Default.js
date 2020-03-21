$(function() {
    let pmService = easyAbp.privateMessaging.privateMessages.privateMessage;
    let notificationService = easyAbp.privateMessaging.privateMessageNotifications.privateMessageNotification;
    let detailModal = new abp.ModalManager(abp. appPath + 'PrivateMessaging/PrivateMessages/PrivateMessage/DetailModal');
    var widgetManager = new abp.WidgetManager({filterForm: 'PmNotification'});

    $(document.body).on('click', '#pmNotificationShowMore', function () {
        document.location.href = "/PrivateMessaging/PrivateMessages/PrivateMessage/Inbox"
    });

    $(document.body).on('click', '#pmNotificationHideThese', function () {
        let ids = [];
        $('.pmNotification-data-text').each(function () {
            ids.push($(this).attr('notificationId'));
        });
        if (ids.length === 0) return;
        notificationService.delete(ids)
            .then(function () {
                refresh();
            })
    });

    $(document.body).on('click', '.pmNotification-data-text', function () {
        let id = $(this).attr('pmid');
        pmService.setRead([id])
            .then(function () {
                refresh();
                detailModal.open({ id: id });
            })
    });

    $(document.body).on('click', '.pmNotification-action-hide', function () {
        let id = $(this).attr('notificationId');
        notificationService.delete([id])
            .then(function () {
                refresh();
            })
    });
    
    function refresh() {
        $('#PrivateMessageTable').DataTable().ajax.reload();
        widgetManager.refresh();
    }
});