
// 获取元素属性
export function getElementPropertyById(id, propertys) {
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

// 获取样式
export function getComputedStyleById(id, property) {
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
export function getComputedStylesById(id, propertys) {
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