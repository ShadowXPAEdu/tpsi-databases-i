/*
*
*   Ficha 1
*   TPSI
*   Pedro dos Santos Alves
*
*/

/*
*
*   2 de Março de 2018
*
*/

/* Ex 1 #21 */
SELECT * FROM AUTORES;

/* Ex 2 #19 */
SELECT TITULO FROM LIVROS;

/* Ex 3 #4 */
SELECT DISTINCT GENERO FROM LIVROS;

/* Ex 4 #8 */
SELECT TITULO FROM LIVROS WHERE PRECO_TABELA > 20 AND PRECO_TABELA < 30;

/* Ex 5 #11 */
SELECT CODIGO_LIVRO, TITULO FROM LIVROS WHERE GENERO = 'Informática';

/* Ex 6 #2 */
SELECT TITULO FROM LIVROS WHERE GENERO = 'Policial' AND PAGINAS > 500;

/* Ex 7 #14 */
SELECT TITULO, GENERO FROM LIVROS WHERE PAGINAS > 500 OR PRECO_TABELA > 30;

/* Ex 8 #11 */
SELECT TITULO FROM LIVROS WHERE GENERO = 'Informática' ORDER BY PRECO_TABELA DESC;

/*
*
*   9 de Março de 2018
*
*/

/* Ex 9 #3 */
SELECT ISBN, TITULO FROM LIVROS WHERE GENERO = 'Policial' ORDER BY QUANT_EM_STOCK ASC, PRECO_TABELA DESC;

/* Ex 10 #6 */
SELECT AUTORES.CODIGO_AUTOR, AUTORES.NOME FROM AUTORES WHERE NOT EXISTS
(SELECT LIVROS.CODIGO_AUTOR FROM LIVROS WHERE AUTORES.CODIGO_AUTOR = LIVROS.CODIGO_AUTOR);

/* Ex 11 #16 */
SELECT TITULO FROM LIVROS WHERE GENERO != 'Policial';

/* Ex 12 #4 */
SELECT NOME FROM AUTORES WHERE IDADE > 30 AND GENERO_PREFERIDO = 'Policial' ORDER BY NOME ASC;

/* Ex 13 #16 */
SELECT TITULO FROM LIVROS WHERE NOT GENERO = 'Policial';

/* Ex 14 #0 */
SELECT NOME FROM AUTORES WHERE NOME LIKE '%c%' AND NOME LIKE '%f%';

/* Ex 15 #2 */
SELECT TITULO FROM LIVROS WHERE TITULO LIKE 'O%st%' OR TITULO LIKE 'M%to%';

/* Ex 16 #16 */
SELECT TITULO FROM LIVROS WHERE GENERO = 'Policial' OR GENERO = 'Romance' OR GENERO = 'Informática';

SELECT TITULO FROM LIVROS WHERE GENERO IN('Policial', 'Romance', 'Informática');

/* Ex 17 #19 */
SELECT 'O livro "' || TITULO || '" custa ' || PRECO_TABELA || ' euros.' AS DESCRICAO_PRECO FROM LIVROS;

/* Ex 18 #1 */
SELECT LIVROS.TITULO, AUTORES.NOME FROM LIVROS, AUTORES WHERE AUTORES.NOME = 'Cláudio Tereso' AND GENERO = 'Policial' AND LIVROS.CODIGO_AUTOR = AUTORES.CODIGO_AUTOR;

/* Ex 19 #1 */
SELECT DISTINCT LIVROS.TITULO FROM LIVROS, AUTORES WHERE GENERO = 'Policial' AND AUTORES.MORADA LIKE '%Coimbra' AND LIVROS.CODIGO_AUTOR = AUTORES.CODIGO_AUTOR;

/* Ex 20 #10 */
SELECT DISTINCT NOME FROM AUTORES, LIVROS WHERE AUTORES.GENERO_PREFERIDO = LIVROS.GENERO AND AUTORES.CODIGO_AUTOR = LIVROS.CODIGO_AUTOR;

/* Ex 21 #1 */
SELECT LIVROS.TITULO, CLIENTES.NOME FROM LIVROS, CLIENTES, VENDAS WHERE CLIENTES.MORADA LIKE '%Coimbra' AND CLIENTES.CODIGO_CLIENTE = VENDAS.CODIGO_CLIENTE AND VENDAS.CODIGO_LIVRO = LIVROS.CODIGO_LIVRO;

/* Ex 22 #3 */
SELECT TITULO, GENERO FROM LIVROS WHERE NOT GENERO IN('Policial', 'Romance') AND TITULO LIKE 'O%';

/* Ex 23 #19 */
SELECT LIVROS.TITULO, ROUND(LIVROS.PRECO_TABELA*0.3, 2) AS RENDEU FROM LIVROS;

/* Ex 24 #3 */
SELECT TITULO FROM LIVROS, VENDAS WHERE (VENDAS.PRECO_UNITARIO*VENDAS.QUANTIDADE) > 100 AND VENDAS.CODIGO_LIVRO = LIVROS.CODIGO_LIVRO ORDER BY GENERO ASC, PRECO_TABELA ASC;

/*
*
*   16 de Março de 2018
*
*/

/* Ex 25 #10 */
SELECT TITULO, ROUND(PRECO_TABELA/PAGINAS, 3) AS "Preço por página" FROM LIVROS WHERE PAGINAS BETWEEN 400 AND 700 ORDER BY ROUND(PRECO_TABELA/PAGINAS, 3) ASC;

/* Ex 26 #19 */
SELECT TITULO, PRECO_TABELA AS "Preço em Euros", ROUND(PRECO_TABELA*200.482, 2) AS "Preço em Escudos" FROM LIVROS;
