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
        DotNet.invokeMethodAsync("CarbonBlazor", "HandleDocumentClick", paths);
    } catch (e) {
    }
});

// 用于需要 尺寸变化的 组件
window.addEventListener("resize", function (event) {
    try {
        DotNet.invokeMethodAsync("CarbonBlazor", "HandleWindowResizeChange", {
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

// 获取元素属性
window.findElementPropertyById = (id, propertys) => {
    var element = document.getElementById(id);
    if (element != null) {
        if (propertys.length == 1) {
            return element[propertys[0]];
        }
        else if (propertys.length == 2) {
            return element[propertys[0]][propertys[1]];
        }
        else if (propertys.length == 3) {
            return element[propertys[0]][propertys[1]][propertys[2]];
        }
        else if (propertys.length == 4) {
            return element[propertys[0]][propertys[1]][propertys[2]][propertys[3]];
        }
    }
    return null;
}

// 设置样式
window.setStyleByIdAsync = (id, property, value) => {
    var element = document.getElementById(id);
    if (element != null) {
        element.style[property] = value;
    }
}

// 获取样式
window.findComputedStyleById = (id, property) => {
    var element = document.getElementById(id);
    if (element != null) {
        var value = getComputedStyle(element, false)[property];
        if (value == null) {
            return "_null_";
        }
        return value;
    }
    return "_null_";
}

// 获取多个样式
window.findComputedStylesById = (id, propertys) => {
    var element = document.getElementById(id);
    if (element != null) {
        var values = [];
        for (var i = 0; i < propertys.length; i++) {
            var value = getComputedStyle(element, false)[propertys[i]];
            if (value == null) {
                values[i] = "_null_";
            }
            else {
                values[i] = value;
            }
        }
        return values;
    }
    return [""];
}