using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UITesting;

namespace LoginCodedUITestProject
{
public class UIMapContainer<TRootUIMap>
{
    private readonly TRootUIMap uiMap;
    private readonly Dictionary<Type, object> uiMaps;

    public UIMapContainer()
    {
        uiMaps = new Dictionary<Type, object>();
        uiMap = Activator.CreateInstance<TRootUIMap>();
    }

    public UIMapContainer<TRootUIMap> Configure<TUIMap>(
        Func<TRootUIMap, UITestControl> rootUiControl,
        Func<TUIMap, UITestControl> targetUiControl)
    {
        var type = typeof(TUIMap);

        var requestedUIMap = Activator.CreateInstance<TUIMap>();

        targetUiControl(requestedUIMap).CopyFrom(rootUiControl(uiMap));

        uiMaps.Add(type, requestedUIMap);

        return this;
    }

    public TRootUIMap UIMap
    {
        get { return uiMap; }
    }

    public TUIMap Get<TUIMap>()
    {
        var type = typeof(TUIMap);
        if (uiMaps.ContainsKey(type))
            return (TUIMap)uiMaps[type];
        throw new UIMapNotFound(type.FullName);
    }

    public class UIMapNotFound : Exception
    {
        public UIMapNotFound(string fullName)
            : base("UIMap is not configured : " + fullName)
        {

        }
    }
}
}