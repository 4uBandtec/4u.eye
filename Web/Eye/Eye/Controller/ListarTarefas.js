function listar() {
    PageMethods.ListarTarefas(onSuccess, onError);

}

function onSuccess(lista) {
    console.log(lista);
}

function onError(erro) {
    console.log(erro);
}