angular.module("cupertino").service("productService", ["cupertinoConfiguration", "$http", function (cupertinoConfiguration, $http) {

    this.endpoint = (method) => {
        return cupertinoConfiguration.backendUrl + "/Product/" + (method || "");
    }

    this.endpointApi = () => {
        return cupertinoConfiguration.backendUrl + "/api/Product/";
    }

    this.search = (productName) => {
        let url = this.endpointApi() + "Search?productName=" + (productName || "");
        return $http.get(url).then(response => response.data);
    }

    this.get = (entityId) => {
        let url = this.endpointApi() + entityId;
        return $http.get(url).then(response => response.data);
    }

    this.save = (entity) => {
        let url = this.endpointApi();

        if (entity.id) {
            return $http.put(url, entity)
        }
        
        return $http.post(url, entity);
    }

    this.delete = (entityId) => {
        let url = this.endpointApi() + entityId;
        return $http.delete(url);
    }

}]);