var Entity = $("model").data("entity");

var SolicitudEdit = new Vue({
    //Data
    data: {

        model: Entity/*,*/
        //count:0,
    },
    //Metodos
    methods: {
        Save: function () {
            Loading.fire("Guardando...");
            axios.post("Solicitud/Save", this.model).then(function (get) {
                Loading.close();
                var result = get.data;

                if (result.CodeError == 0) {
                    Toast.fire({
                        icon: 'success',
                        title: 'Registro Guardado'

                    });
                    setTimeout(function () {
                        window.location.href = "../Solicitud"
                    }, 1500)

                } else {
                    Toast.fire({
                        icon: 'Error',
                        title: result.MsgError

                    });
                }
            });
        }
    },
    //Create


});

SolicitudEdit.$mount("#SolicitudEdit");