angular.module("myApp", []);

angular.module("myApp").controller("computadorCtrl", function ($http) {
    var self = this;
    self.computadores = {};
    self.columns = ["Id", "Marca", "Modelo", "Preço", "Polegadas", "Peso"]
    self.toggleEdit = false;
    self.toggleAdd = false;
    self.clone = {};

    $http.get("http://localhost:54077/api/Computador/").then(function (res) {
        self.computadores = res.data;
    });
    self.delete = function (obj) {
        $http.delete("http://localhost:54077/api/Computador/" + obj.Id).then(function (res) {
            var index = self.computadores.indexOf(obj);
            self.computadores.splice(index, 1);
        });
    };
    self.edit = function (obj) {
        $http.put("http://localhost:54077/api/Computador/" + obj.Id, obj).then(function (res) {
            console.log("Funcionou");
        });
    };
    self.add = function (obj) {
        $http.post("http://localhost:54077/api/Computador/", obj).then(function (res) {
            for (var prop in obj)
                obj[prop] = "";
            self.computadores.push(res.data);
        });
    };
    self.cloneItem = function (obj) {
        self.clone = angular.copy(obj);
    };
    self.cancel = function (index) {
        self.computadores[index] = self.clone;
    }
});