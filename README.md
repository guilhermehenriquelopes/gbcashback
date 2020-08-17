<h1>API - Cashback</h1>

Esta API REST foi construída para atender os requisitos solicitados no processo seletivo
da AsapLog.

<p>
Para facilitar os testes a aplicação foi publicada na plataforma Heroku, 
e pode ser acessada através do link: <a href="https://seguradora.herokuapp.com/swagger-ui.html">https://seguradora.herokuapp.com/swagger-ui.html</a> 
</p>

<h3>Ferramentas utilizadas: </h3>
<ul>
    <li>Spring Boot 2.2.4</li>
    <li>Gradle</li>
    <li>JDK 11</li>
    <li>MongoDB 4.4</li>
    <li>Swagger 2</li>
    <li>IDE: IntelliJ Communit</li>
</ul>

<h3>Documentação com os Requisitos Solicitados:</h3>
<ul>
    <li>CRUD de clientes: <a href="https://seguradora.herokuapp.com/swagger-ui.html#/cliente-controller">swagger-ui.html#/cliente-controller</a></li>
    <li>CRUD de apólices: <a href="https://seguradora.herokuapp.com/swagger-ui.html#/apolice-controller">swagger-ui.html#/apolice-controller</a></li>
    <li>Consulta apólice por número: <a href="https://seguradora.herokuapp.com/swagger-ui.html#/gestao-controller/apoliceDetailUsingGET">swagger-ui.html#/gestao-controller</a></li>
    <li>Finalização: 
        <ul>
            <li>Criar guia para setup do projeto e instruções para rodar: 
                <br />Integração contínua na plataforma <a href="https://seguradora.herokuapp.com/">Heroku</a></li>
            <li>Gerar .jar ou .war para rodar o projeto: 
                <br />Executar <code>./gradlew  clean build -x test</code> 
                <br />Encontrar o arquivo na raíz do projeto<code>/build/libs</code>
            </li>
            <li>GitHub <a href="https://github.com/guilhermehenriquelopes/seguradora.git">https://github.com/guilhermehenriquelopes/seguradora.git</a> </li>
        </ul>
    </li>
</ul>

<h3>Requisitos para deploy local</h3>

<a href="https://docs.docker.com/install/linux/docker-ce/ubuntu/">- Instalação Docker</a>

Verifique a versão do docker instalado na sua máquina:        
<code>docker -v</code>

A saída deve ser similar a isto:        
<code>Docker version 19.03.7, build 7141c199a2</code>    

<a href="https://www.oracle.com/java/technologies/javase-jdk11-downloads.html">- Instalação JDK 11</a>

Verifique a versão do JDK instalado:        
<code>java -version</code>

A saída deve ser similar a isto:        
<code>openjdk version "11.0.6" 2020-01-14</code>

<a href="https://gradle.org/install/">- Instalação Gradle</a>

Verifique a versão do Gradle instalado: <br/>
<code>./gradlew -v</code>

<h3>Rodando a aplicação:</h3>

<ol>
    <li>Clonar o repositório na sua máquina</li>
    <li>Abrir o terminal</li>
    <li>Navegue até a raíz do projeto, pasta onde se encontra o Dockerfile</li>
    <li>Inicie o docker caso ainda não esteja sendo executado</li>
    <li>Rode o comando abaixo para buildar o projeto e criar a imagem: <br />
        <code>docker build -f Dockerfile -t seguradora .</code>        
    </li>
    <li>Rodo o comando abaixo para iniciar a aplicação: <br />
        <code>docker run -p 9091:9091 seguradora</code>
    </li>
    <li>Verifique se a aplicação está rodando na seguinte URL: <br />
        <a href="http://localhost:9091/swagger-ui.html">http://localhost:9091/swagger-ui.html</a>
     </li>
</ol>
