using System;
using JetBrains.Annotations;
using Volo.Abp.ObjectExtending;

namespace EasyAbp.PrivateMessaging.PrivateMessages;

[Serializable]
public class CreatePrivateMessageInfoModel : ExtensibleObject
{
    public Guid? FromUserId { get; set; }

    public Guid ToUserId { get; set; }

    [NotNull]
    public string Title { get; set; } = null!;

    [CanBeNull]
    public string Content { get; set; }

    [CanBeNull]
    public string Category { get; set; }

    public CreatePrivateMessageInfoModel()
    {
    }

    public CreatePrivateMessageInfoModel(
        Guid? fromUserId, 
        Guid toUserId, 
        [NotNull] string title,
        [CanBeNull] string content, 
        string category = null)
    {
        FromUserId = fromUserId;
        ToUserId = toUserId;
        Title = title;
        Content = content;
        Category = category;
    }
}