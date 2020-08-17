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

