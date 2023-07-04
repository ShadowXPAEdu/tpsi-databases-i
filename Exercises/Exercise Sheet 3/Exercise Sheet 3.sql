/*
*
*   Ficha 3
*   TPSI
*   Pedro dos Santos Alves
*
*/

/*
*
*   6 de Abril de 2018
*
*/

/* Ex 1 #2 */
SELECT AUTORES.NOME AS "Nome do autor", MIN(LIVROS.PRECO_TABELA) AS "Preço mínimo"
FROM AUTORES, LIVROS
WHERE AUTORES.CODIGO_AUTOR = LIVROS.CODIGO_AUTOR
GROUP BY AUTORES.NOME
HAVING MIN(LIVROS.PRECO_TABELA) >= 50
ORDER BY MIN(LIVROS.PRECO_TABELA) ASC;

/* Ex 2 #1 */
SELECT CLIENTES.NOME AS "Nome", COUNT(VENDAS.QUANTIDADE) AS "Nº de Livros", ROUND(AVG(VENDAS.PRECO_UNITARIO), 2) AS "Preço Médio", COUNT(LIVROS.CODIGO_AUTOR) AS "Nº Autores diferentes"
FROM CLIENTES, VENDAS, LIVROS
WHERE CLIENTES.CODIGO_CLIENTE = VENDAS.CODIGO_CLIENTE AND CLIENTES.MORADA LIKE '%Lisboa' AND LIVROS.CODIGO_LIVRO = VENDAS.CODIGO_LIVRO
GROUP BY CLIENTES.NOME
HAVING COUNT(VENDAS.QUANTIDADE) > 3
ORDER BY ROUND(AVG(VENDAS.PRECO_UNITARIO), 2) ASC;

/* Ex 3 #1 */
SELECT LIVROS.GENERO AS "Genero", TRUNC(AVG(LIVROS.PRECO_TABELA), 0) AS "Preço Médio"
FROM LIVROS
GROUP BY LIVROS.GENERO
HAVING COUNT(LIVROS.GENERO) > 4
ORDER BY TRUNC(AVG(LIVROS.PRECO_TABELA), 0) ASC;

/* Ex 4 #1 */
SELECT EDITORAS.NOME AS "Editora", LIVROS.GENERO AS "Genero", MAX(LIVROS.UNIDADES_VENDIDAS) AS "Maximo", MIN(LIVROS.UNIDADES_VENDIDAS) AS "Mínimo", TRUNC(AVG(LIVROS.UNIDADES_VENDIDAS), 0) AS "Médio", COUNT(LIVROS.GENERO) AS "Nº Livros"
FROM EDITORAS, LIVROS, AUTORES
WHERE EDITORAS.CODIGO_EDITORA = LIVROS.CODIGO_EDITORA AND AUTORES.NOME NOT LIKE 'Paulo%Loureiro' AND AUTORES.CODIGO_AUTOR = LIVROS.CODIGO_AUTOR
GROUP BY EDITORAS.NOME, LIVROS.GENERO
HAVING MAX(LIVROS.UNIDADES_VENDIDAS) > 10000
ORDER BY EDITORAS.NOME ASC, LIVROS.GENERO ASC, MAX(LIVROS.UNIDADES_VENDIDAS) ASC;

/* Ex 5 #6 */
SELECT AUTORES.NOME AS "Nome"
FROM AUTORES
WHERE AUTORES.CODIGO_AUTOR NOT IN (
    SELECT LIVROS.CODIGO_AUTOR
    FROM LIVROS);

/* Ex 6 #15 */
SELECT AUTORES.NOME, LPAD(NVL(COUNT(LIVROS.CODIGO_LIVRO), 0), 10) AS "Nº Livros"
FROM AUTORES, LIVROS
WHERE AUTORES.CODIGO_AUTOR = LIVROS.CODIGO_AUTOR
GROUP BY AUTORES.NOME
ORDER BY AUTORES.NOME;

/* Ex 7 a) #1 */
SELECT LIVROS.TITULO, TRUNC(LIVROS.PRECO_TABELA) AS "Preço Tabela"
FROM LIVROS
WHERE LIVROS.PRECO_TABELA = (SELECT MAX(LIVROS.PRECO_TABELA) FROM LIVROS WHERE GENERO = 'Informática');

/* Ex 7 b) #19 */
SELECT LIVROS.TITULO, TRUNC(LIVROS.PRECO_TABELA) AS "Preço Tabela"
FROM LIVROS;

/* Ex 7 c) #11 */
SELECT LIVROS.TITULO, TRUNC(LIVROS.PRECO_TABELA) AS "Preço Tabela"
FROM LIVROS
WHERE EXISTS(SELECT LIVROS.PRECO_TABELA FROM LIVROS WHERE GENERO = 'Informática') AND GENERO = 'Informática';

/*
*
*   13 de Abril de 2018
*
*/

/* Ex 7 d) #1 */
SELECT LIVROS.TITULO, TRUNC(LIVROS.PRECO_TABELA) AS "Preço Tabela"
FROM LIVROS
WHERE LIVROS.PRECO_TABELA = (SELECT MAX(LIVROS.PRECO_TABELA) FROM LIVROS WHERE GENERO = 'Informática');

/* Ex 8 #11 */
SELECT AUTORES.NOME, LIVROS.PAGINAS, AVG(LIVROS.PAGINAS)
FROM AUTORES, LIVROS
WHERE AUTORES.CODIGO_AUTOR = LIVROS.CODIGO_AUTOR AND LIVROS.PAGINAS > (SELECT AVG(LIVROS.PAGINAS) FROM LIVROS)
GROUP BY AUTORES.NOME, LIVROS.PAGINAS
ORDER BY AUTORES.NOME ASC;

SELECT TRUNC(AVG(LIVROS.PAGINAS), 0)
FROM LIVROS;

/* Ex 9 #11 */
SELECT LIVROS.TITULO AS "Titulo", LIVROS.PRECO_TABELA AS "Preço", AVG(LIVROS.PRECO_TABELA) AS "Preço Médio", (LIVROS.PRECO_TABELA - AVG(LIVROS.PRECO_TABELA)) AS "Diferença"
FROM LIVROS, AUTORES
WHERE LIVROS.CODIGO_AUTOR = AUTORES.CODIGO_AUTOR AND LIVROS.GENERO = 'Informática'
GROUP BY LIVROS.TITULO, LIVROS.PRECO_TABELA;

/* Ex 10 #11 */ -- Não funciona???? --
SELECT 'Informática' as "Genero", '####################################################' AS "Título"
FROM dual
UNION
SELECT '    "', LIVROS.TITULO
FROM LIVROS
WHERE LIVROS.GENERO = 'Informática'
ORDER BY 1 DESC, "Título" DESC;

/* Ex 11 #19 */
SELECT AUTORES.NOME, NVL(LIVROS.TITULO, ' ')
FROM AUTORES, LIVROS
WHERE AUTORES.CODIGO_AUTOR = LIVROS.CODIGO_AUTOR;

/* Ex 13 #4 */
SELECT LIVROS.GENERO, LIVROS.TITULO, LIVROS.UNIDADES_VENDIDAS
FROM LIVROS, (
    SELECT LIVROS.GENERO AS Genero, MAX(LIVROS.UNIDADES_VENDIDAS) AS Maximo
    FROM LIVROS
    GROUP BY LIVROS.GENERO) X
WHERE LIVROS.GENERO = X.Genero AND X.Maximo = LIVROS.UNIDADES_VENDIDAS
ORDER BY LIVROS.GENERO ASC;

/*
*
*   20 de Abril de 2018
*
*/

/* Ex 14 #14 */
SELECT LIVROS.TITULO AS "Título", ROUND(LIVROS.UNIDADES_VENDIDAS/929874*100, 2) AS "Percentagem"
FROM LIVROS, EDITORAS
WHERE LIVROS.CODIGO_EDITORA = EDITORAS.CODIGO_EDITORA AND EDITORAS.NOME LIKE '%FCA%'
GROUP BY LIVROS.TITULO, ROUND(LIVROS.UNIDADES_VENDIDAS/929874*100, 2)
ORDER BY "Percentagem" DESC;

SELECT SUM(LIVROS.UNIDADES_VENDIDAS)
FROM LIVROS;

/* Ex 15 #1 */
SELECT LIVROS.TITULO AS "Título"
FROM LIVROS, VENDAS, CLIENTES
WHERE LIVROS.CODIGO_LIVRO = VENDAS.CODIGO_LIVRO AND CLIENTES.CODIGO_CLIENTE = VENDAS.CODIGO_CLIENTE AND CLIENTES.MORADA LIKE '%Lisboa' AND VENDAS.QUANTIDADE =
    (SELECT MAX(VENDAS.QUANTIDADE)
    FROM VENDAS);

-- Output diferente?? --
SELECT DISTINCT LIVROS.TITULO AS "Título"
FROM LIVROS, CLIENTES, (
    SELECT MAX(LIVROS.UNIDADES_VENDIDAS) AS maximo
    FROM LIVROS)X, (
    SELECT CLIENTES.MORADA AS morada
    FROM CLIENTES
    WHERE CLIENTES.MORADA LIKE '%Lisboa')Y
WHERE LIVROS.UNIDADES_VENDIDAS = X.maximo AND CLIENTES.MORADA = Y.morada;

/* Ex 16 #1 */
SELECT X.TOTAL AS "Total de Livros", Y.TOTAL_AU AS "Total de Autores", Z.TOTAL_ED AS "Total de Editoras"
FROM (
    SELECT COUNT(LIVROS.CODIGO_LIVRO) AS TOTAL
    FROM LIVROS)X, (
    SELECT COUNT(AUTORES.CODIGO_AUTOR) AS TOTAL_AU
    FROM AUTORES)Y, (
    SELECT COUNT(EDITORAS.CODIGO_EDITORA) AS TOTAL_ED
    FROM EDITORAS)Z;

/* Ex 17 #? */
SELECT 'O autor ' || AUTORES.NOME || ' escreveu ' || ' de ' || ' livros para a editora FCA - EDITORA.' AS "Resultado"
FROM AUTORES, LIVROS, (
    SELECT COUNT(CODIGO_LIVRO) AS editados
    FROM AUTORES, LIVROS, EDITORAS
    WHERE LIVROS.CODIGO_EDITORA = EDITORAS.CODIGO_EDITORA AND AUTORES.CODIGO_AUTOR = LIVROS.CODIGO_AUTOR AND EDITORAS.CODIGO_EDITORA = '1')X
ORDER BY AUTORES.NOME, LIVROS.TITULO;
