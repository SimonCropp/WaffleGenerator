let handler;

window.Connection = {
    Initialize: function (interop) {

        handler = function () {
            interop.invokeMethodAsync("Connection.StatusChanged", navigator.onLine);
        }

        window.addEventListener("online", handler);
        window.addEventListener("offline", handler);

        handler(navigator.onLine);
    },
    Dispose: function () {

        if (handler != null) {

            window.removeEventListener("online", handler);
            window.removeEventListener("offline", handler);
        }
    }
};