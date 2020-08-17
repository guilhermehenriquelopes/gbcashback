<h1>API - Cashback</h1>

API REST construída para retornar benefícios em forma de Cashback para revendedores de acordo com o volume de vendas.

<h3>Ferramentas utilizadas</h3>
<ul>
    <li>Linguagem: C# 8.0</li>
    <li>Framework: ASP.NET Core 3.1</li>
    <li>Banco de Dados: SQL Server 2019</li>    
    <li>Swagger 2</li>
    <li>IDE: Visual Studio Code</li>
</ul>

<h3>Requisitos back-end</h3>
<ul>
    <li>Rota para cadastrar um novo revendedor(a) exigindo no mínimo nome completo, CPF,
e- mail e senha: <a href="">[POST] /api/Revendedor </a></li>
    <li>Rota para ativar o cadastro de um revendedor(a): <a href="">[GET] /api/Revendedor/{cpf}/ativar</a></li>
    <li>Rota para validar um login de um revendedor(a): <a href="">[POST] /api/Usuario</a></li>    
    <li>Rota para cadastrar uma nova compra exigindo no mínimo código, valor, data e CPF do revendedor(a): <a href="">[POST] /api/Compra</a></li>
    <li>Rota para listar as compras cadastradas: <a href="">[GET] /api/Compra</a></li>
    <li>Rota para listar as compras cadastradas por CPF: <a href="">[GET] /api/Compra/{cpf}</a></li>
    <li>Rota para exibir o acumulado de cashback até o momento (banco da aplicação): <a href=""></a></li>
    <li>Rota para exibir o acumulado de cashback até o momento (API Boticário): <a href=""></a></li>    
</ul>

<h3>Diferenciais</h3>
<ul>
    <li>Testes unitários: </li>
</ul>
