using JetBrains.Annotations;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace EasyAbp.PrivateMessaging.UnifiedDemo.EntityFrameworkCore;

public class UnifiedDemoModelBuilderConfigurationOptions(
   [NotNull] string tablePrefix = "",
   [CanBeNull] string schema = null) : AbpModelBuilderConfigurationOptions(
       tablePrefix,
       schema)
{
}
