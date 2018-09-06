# projeto_piloto
Projeto piloto de backend

Este projeto tem como finalidade implementar o backend de uma tasklist, utilizando .Net Core como base.
Para o banco de dados foi utilizado SQL Server, onde o script para criação das tabelas se encontrar no arquivo tables.sql.

# Swagger:

Como documentação e também ambiente para testes das APIs, foi utilizado o Swagger. Através do Swagger é possível visualizar os APIs disponíveis e quais parâmetros são necessários em cada uma.

Exemplo de endereço para acesso ao swagger da aplicação: https://localhost:44370/swagger

A implementação do backend foi implementada em .Net Core, utilizando o Entity Framework para modelar e se comunicar com banco de dados.

# Segurança:

Foi utilizado JWT para a parte de segurança das APIs, onde só a API de login está disponível sem autenticação. 
Essa API retorna um token que será utilizado (bearer + token) para autenticação nas demais rotas.
Em um ambiente de produção, seria utilizado um certificado digital para garantir a segurança dos dados trafegados. Por se tratar de um exemplo, neste caso a senha é passado por parâmetro na URL sem a devida proteção.

# Automapper:

Para o mapeamento dos modelos de objetos para as entidades, foi utilizado Automapper.

# Arquitetura:

O padrão de arquitetura do projeto está baseado em serviços, onde cada serviço tem sua responsabilidade e trabalha com o menor acoplamento possível entre as classes. Para diminuir ao máximo o acoplamento, é utilizada a injeção de dependencia e implementação de interfaces, desde o nível de repositório.
