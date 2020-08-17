<h1>API - Cashback</h1>

API REST construída para retornar benefícios em forma de Cashback para revendedores de acordo com o volume de vendas.

Para facilitar os testes a aplicação foi publicada na plataforma Heroku, e pode ser acessada através do link: https://gbcashback.herokuapp.com/

<h3>Ferramentas utilizadas</h3>
<ul>
    <li>Linguagem: C# 8.0</li>
    <li>Framework: ASP.NET Core 3.1</li>
    <li>Banco de Dados: SQL Server 2019</li>    
    <li>Swagger 2</li>
    <li>IDE: Visual Studio Code</li>
</ul>

<h3>Requisitos back-end</h3>

<i><b>Obs.: qualquer cadastro com o CPF 153.509.460-56 entra automaticamente com o status "Ativado"</b></i>

<ul>
    <li>Rota para cadastrar um novo revendedor(a) exigindo no mínimo nome completo, CPF,
e- mail e senha: <b>[POST] /api/Revendedor </b></li>
    <li>Rota para ativar o cadastro de um revendedor(a): <b>[GET] /api/Revendedor/{cpf}/ativar</b></li>
    <li>Rota para validar um login de um revendedor(a): <b>[POST] /api/Usuario</b></li>    
    <li>Rota para cadastrar uma nova compra exigindo no mínimo código, valor, data e CPF do revendedor(a): <b>[POST] /api/Compra</b></li>
    <li>Rota para listar as compras cadastradas: <b>[GET] /api/Compra</b></li>
    <li>Rota para listar as compras cadastradas por CPF: <b>[GET] /api/Compra/{cpf}</b></li>
    <li>Rota para exibir o acumulado de cashback até o momento (banco da aplicação): <b>/api/Conta/{cpf}/acumulado</b></li>
    <li>Rota para exibir o acumulado de cashback até o momento (API Boticário): <b>/api/Conta/{cpf}/acumuladoapi</b></li>
</ul>

<h3>Diferenciais</h3>
<ul>
    <li>Autenticação JWT
        <br /><p>Para autenticar na API é necessário enviar o Tokek gerado pelo método [POST] /api/Usuario, informando cpf e senha de um Revendedor (Ativado)</p>
        <ul>
            <li>[POST] /api/Revendedor - Método sem autenticação</li>
            <li>[POST] /api/Compra - Método sem autenticação</li>
            <li>[POST] /api/Usuario - Método sem autenticação</li>
            <li>[POST] /api/Conta/{cpf}/acumuladoapi (método retorna o consumo da API do Boticário)</li>                        
        </ul>
    </li>
    <li>Testes Unitários: <a href=""><a/></li>
    <li>Testes de Integração: <a href=""><a/></li>
</ul>

<h3>Utilizando o token</h3>
<p>Usuário já criado no banco: cpf = 634.696.940-44, senha = 123456</p>
<ul>
    <li>Pela interface do Swagger clique no botão <b>Authorize</b></li>
    <li>Na tela que abrir digite <b>Bearer {token}</b></li>
        <ul><li>Ex.: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI66IjE1My41MDkuNDYwLTU2IiwibmJmIjoxNTk3Njk0MjU5LCJleHAiO </li></ul>
    <li>Via outros clients, informe o Bearer através do header authorization</li>
</ul>
