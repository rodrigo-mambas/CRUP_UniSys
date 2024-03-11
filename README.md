# Desenvolvimento de uma API RESTful

O candidato deverá desenvolver uma API RESTful utilizando ASP.Net Core e PostgreSQL. Implementar os seguintes requisitos:

1. Criar um endpoint para listar todos os usuários cadastrados no sistema.
2. Criar um endpoint para cadastrar um novo usuário no sistema.
3. Criar um endpoint para atualizar as informações de um usuário existente.
4. Criar um endpoint para excluir um usuário do sistema.
5. Implementar validações de entrada de dados nos endpoints.
6. Utilizar o padrão CQS (Command Query Separation) para separar operações de leitura (query) e operações de escrita (command).
7. Realizar testes unitários utilizando XUnit para garantir a qualidade do código.
8. Expor as APIs utilizando o Swagger.

Critérios de avaliação:
- Funcionalidade: Os requisitos devem ser implementados corretamente e atender às especificações.
- Qualidade do código: O código deve ser limpo, organizado e seguir as boas práticas de desenvolvimento.
- Testes unitários: Os testes unitários devem ser implementados e garantir a cobertura adequada do código.
- Utilização correta dos conhecimentos técnicos mencionados no perfil.


## Demonstração 
![image](https://github.com/rodrigo-mambas/CRUP_UniSys/assets/57135792/0c64892d-5140-4c4b-9c94-4bf04034c4a5)


## Para Execução
1. ter o docker desktop instalado.
    - Acessar o site https://www.docker.com/products/docker-desktop/ e baixar a versão para o seu sistema operacional.
2. executar o comando abaixo pelo PowerShel
    - docker run -p 5432:5432 -e POSTGRES_PASSWORD=1234 -d postgres
3. no VisualStudio no PackageManagerConsole executar o comando abaixo apontando para o projeto "CRUP.Infra", pois ja deixei a migration no projeto.
    - Update-Database
4. executar o projeto "CRUP.API".

OBS: Com Token implementado.
