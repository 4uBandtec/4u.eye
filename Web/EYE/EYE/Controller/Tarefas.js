function AdicionarPainel() {
    const pnlConfiguracao = document.getElementById("pnlConfiguracao")

    
    const listaDeUsers = pnlConfiguracao.querySelectorAll(".conteudoTarefa")
    const ultimoUser = listaDeUsers[listaDeUsers.length - 1]
    const ultimaPosicaoOcupada = parseInt(listaDeUsers.length - 1)
    let novoUser = ultimoUser.cloneNode(true)
    novoUser.id =  ("conteudo"+(ultimaPosicaoOcupada + 1))
    

    pnlConfiguracao.appendChild(novoUser)
    
}
