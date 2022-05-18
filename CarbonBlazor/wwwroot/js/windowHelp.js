
export const componentEventListeners = {};

export function addEventListener(type, id) {
    var typeComponents = componentEventListeners[type];
    if (typeComponents != undefined) {
        if (!typeComponents.includes(id)) {
            typeComponents.push(id);
        }
    } else {
        componentEventListeners[type] = [id];
        window.addEventListener(type, onCallBack);
    }
}

export function removeEventListener(type, id) {
    var typeComponents = componentEventListeners[type];
    if (typeComponents != undefined) {
        typeComponents.pop(id);
        if (typeComponents.length <= 0) {
            componentEventListeners[type] = undefined;
            window.removeEventListener(type, onCallBack);
        }
    }
}

// 事件回调
export function onCallBack(e) {
    var typeComponents = componentEventListeners[e.type];
    if (typeComponents != undefined) {
        DotNet.invokeMethodAsync("CarbonBlazor", "OnWindowEventCallBack", e.type, e.id);
    }
}