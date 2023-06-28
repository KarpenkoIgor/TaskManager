using MyTaskManager.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace MyTaskManager.Permissions;

public class MyTaskManagerPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(MyTaskManagerPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(MyTaskManagerPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<MyTaskManagerResource>(name);
    }
}
