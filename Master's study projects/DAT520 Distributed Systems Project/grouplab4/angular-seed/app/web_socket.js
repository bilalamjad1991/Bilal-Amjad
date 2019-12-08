angular.module('myApp').factory('WebSocketService', ['$q', '$rootScope', function($q, $rootScope) {
    // We return this object to anything injecting our service
    var Service = {};
    // Keep all pending requests here until they get responses
    var callbacks = {};

    // Client Sequence
    var clientSeq = 0;

    var isopen = false;

    // Create our websocket object with the address to the websocket
    var socket_url = "ws://localhost:3000/ws";
    var ws = new WebSocket(socket_url);

    ws.onopen = function(){
        isopen = true;
        console.log("Socket has been opened!");
    };

    ws.onmessage = function(message) {
        listener(JSON.parse(message.data));
    };
    ws.onclose = function () {
        isopen  = false;
        console.log("Socket is closed");
    };


    function sendRequest(request) {
        clientSeq++;
        var defer = $q.defer();
        callbacks[clientSeq] = {
            cb:defer
        };
        request.data.client_seq = clientSeq;
        console.log('Sending request', request);
        ws.send(JSON.stringify(request));
        return defer.promise;
    }

    function listener(data) {
        var messageObj = data;
        console.log("Received data from websocket: ", messageObj);
       // If an object exists with callback_id in our callbacks object, resolve it
        if(callbacks.hasOwnProperty(messageObj.data.client_seq)) {
            console.log(callbacks[messageObj.data.client_seq]);
            console.log("callbacl aray = ", callbacks);
            console.log("data object  = ", messageObj.data);
            $rootScope.$apply(callbacks[messageObj.data.client_seq].cb.resolve(messageObj));
            delete callbacks[messageObj.data.client_seq];
        }
    }

    // Define a "getter" for getting customer data
    Service.getCustomers = function() {
        var request = {
            type: "get_customers"
        }
        // Storing in a variable for clarity on what sendRequest returns
        var promise = sendRequest(request);
        return promise;
    };
    Service.createAccount = function (data) {
        var request = {
            type: "Signup",
            data: data
        };
        var promise = sendRequest(request);
        return promise
    };

    Service.Login = function (data) {
      var request = {
          type: "Signin",
          data: data
      };
      var promise = sendRequest(request);
      return promise;
    };
    Service.Transaction = function (data) {
      var request = {
          type: "Txn",
          data: data
      };
        var promise = sendRequest(request);
        return promise
    };
    Service.CloseSocket = function () {
        ws.close();
    };

    return Service;
}]);
