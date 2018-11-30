function cadastrarClick() {
    var listaCodUsersTarefa = [];
    var listaProcTarefa = [];
    var listaTempoTarefa = [];

    let index = 0
    document.querySelectorAll(".conteudoTarefa").forEach(item => {
        console.log(item)
        if (item.value == "") {
        }
        else {
            if (item.querySelector(".ddlUsuarios").value != "" && item.querySelector(".ddlProcessos").value != "" && item.querySelector(".txtTempo").value != "") {
                listaCodUsersTarefa[index] = item.querySelector(".ddlUsuarios").value;
                listaProcTarefa[index] = item.querySelector(".ddlProcessos").value;
                listaTempoTarefa[index] = item.querySelector(".txtTempo").value;

                index++;
            }
            else {
                item.remove();
            }
        }
    })

    console.log(listaCodUsersTarefa, listaProcTarefa, listaTempoTarefa);

    PageMethods.CadastraTarefa(listaCodUsersTarefa, listaProcTarefa, listaTempoTarefa, onSuccess, onError);

    return true
}

function AdicionarPainel() {
    const pnlConfiguracao = document.getElementById("pnlConfiguracao")

    
    const listaDeUsers = pnlConfiguracao.querySelectorAll(".conteudoTarefa")
    const ultimoUser = listaDeUsers[listaDeUsers.length - 1]
    const ultimaPosicaoOcupada = parseInt(listaDeUsers.length - 1)
    let novoUser = ultimoUser.cloneNode(true)
    novoUser.id =  ("conteudo"+(ultimaPosicaoOcupada + 1))
    

    pnlConfiguracao.appendChild(novoUser)
    
}
function onSuccess(sucesso) {
    console.log(sucesso);
};
function onError(erro) { console.log("DEU ERROOOOOOOOOO ONKNKSA KBAD J<B JDMB "+erro) };