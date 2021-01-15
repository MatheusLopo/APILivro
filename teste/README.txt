APILivro 


Para poder ver as requisições sendo efetuada no Postman, primeiramente devemos fazer a inserção dos dados
atravéz da url http://localhost:55241/v1/livros.

Após isso basta escolher a ação desejada para ver o retorno.
Devemos passar os parametros de busca como, Id, Nome do livro, Autor pelo header.

URL tipo POST

http://localhost:55241/v1/livros (Url para adcionar livros, passar json pelo body);


URL tipo GET

http://localhost:55241/livros (Url para fazer a listagem de todos os livros);
http://localhost:55241/livros/descending (Url para fazer a listagem dos livros em ordem descendente);
http://localhost:55241/livros/ascendent  (Url para fazer a listagem dos livros em ordem ascendente);
http://localhost:55241/livro/{filterType}/{value} (Nesta Url devemos passar pelo header o parametro filterType e o value, caso filterType = 1 value deve ser o nome do livro,
caso o filterType seja 0 devemos passar o nome do autor);
http://localhost:55241/livro/frete/{Id} (Url para saber o valor do frete, passar valor do id pelo header);


Em APILivroTeste, estão os teste.
Para rodar os testes criados, basta ir na opção Teste>Executar todos os testes.