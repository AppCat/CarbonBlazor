// 用于需要 自动隐藏的 组件
document.addEventListener("click", function (event) {
    try {
        var paths = [];
        for (var i = 0; i < event.path.length; i++) {
            var d = event.path[i];
            if (d == document || d == window)
                continue;
            paths.push({
                id: d.id,
                localName: d.localName.toString(),
                className: d.className.toString()
            });
        }
        DotNet.invokeMethod("CarbonBlazor", "HandleDocumentClick", paths);
    } catch (e) {
    }
});

// 用于需要 尺寸变化的 组件
window.addEventListener("resize", function (event) {
    try {
        DotNet.invokeMethod("CarbonBlazor", "HandleWindowResizeChange", {
            clientWidth: document.documentElement.clientWidth,
            clientHeight: document.documentElement.clientHeight,
            innerHeight: window.innerHeight,
            innerWidth: window.innerWidth,
            outerWidth: window.outerWidth,
            outerHeight: window.outerHeight
        });
    } catch (e) {

    }
});
