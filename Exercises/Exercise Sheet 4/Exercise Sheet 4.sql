/*
*
*   Ficha 4
*   TPSI
*   Pedro dos Santos Alves
*
*/

/*
*
*   20 de Abril de 2018
*
*/

/* Ex 1 #1 */
SELECT AUTORES.NOME, LIVROS.TITULO, COUNT(X.preco) AS Livros
FROM AUTORES, LIVROS, (
    SELECT MAX(LIVROS.PRECO_TABELA) AS preco
    FROM LIVROS, EDITORAS
    WHERE EDITORAS.NOME = 'FCA - EDITORA' AND LIVROS.CODIGO_EDITORA = EDITORAS.CODIGO_EDITORA) X
WHERE AUTORES.CODIGO_AUTOR = LIVROS.CODIGO_AUTOR AND
    LIVROS.PRECO_TABELA IN(X.preco)
GROUP BY AUTORES.NOME, LIVROS.TITULO
;

-- Alt #1
SELECT NOME, TITULO, y.num_livros AS Livros, x.num_livrosEditora AS Total_de_Livros
FROM LIVROS, AUTORES, (
    SELECT CODIGO_AUTOR, COUNT(*) AS num_livros
    FROM LIVROS
    GROUP BY codigo_autor)y,
    (SELECT codigo_autor, COUNT(*) AS num_livrosEditora
    FROM LIVROS, EDITORAS
    WHERE LIVROS.CODIGO_EDITORA = 1 and EDITORAS.CODIGO_EDITORA = 1
    GROUP BY codigo_autor)x
WHERE preco_tabela = (SELECT MAX(preco_tabela) as maximo
    FROM LIVROS, EDITORAS
    WHERE LIVROS.codigo_editora = 1 AND EDITORAS.CODIGO_EDITORA = 1)
AND LIVROS.CODIGO_EDITORA = 1 AND LIVROS.CODIGO_AUTOR = AUTORES.CODIGO_AUTOR
AND LIVROS.CODIGO_AUTOR = x.codigo_autor AND LIVROS.CODIGO_AUTOR = y.codigo_autor
;

/* Ex 2 #10 */ -- Quase acabado falta mostrar 5
SELECT AUTORES.NOME AS "Nome", Y.contagem AS "Género Preferido", Y.cont AS "Total de Livros"
FROM AUTORES,

    (SELECT COUNT(liv.TITULO) AS cont, liv.CODIGO_AUTOR AS Cod_Aut, NVL(X.contagem, 0) AS Contagem
    FROM AUTORES aut, LIVROS liv, (SELECT COUNT(au.NOME) AS contagem, li.CODIGO_AUTOR AS Cod_Au
    FROM AUTORES au, LIVROS li
    WHERE au.CODIGO_AUTOR = li.CODIGO_AUTOR
    AND li.GENERO = au.GENERO_PREFERIDO
    GROUP BY li.CODIGO_AUTOR) X
    WHERE aut.CODIGO_AUTOR = liv.CODIGO_AUTOR
    AND aut.CODIGO_AUTOR = X.Cod_Au
    GROUP BY liv.CODIGO_AUTOR, NVL(X.contagem, 0)) Y

WHERE Y.Cod_Aut = AUTORES.CODIGO_AUTOR
;

-- Ex 2 Correcto #21
SELECT DISTINCT NOME, NVL(X.GENERO_PREF, 0) AS "Género Preferido", NVL(Y.TOTAL, 0) AS "Total de Livros"
FROM AUTORES, LIVROS, (
    SELECT AUTORES.CODIGO_AUTOR AS AUTOR, COUNT(*) AS GENERO_PREF
    FROM AUTORES, LIVROS
    WHERE AUTORES.CODIGO_AUTOR = LIVROS.CODIGO_AUTOR AND AUTORES.GENERO_PREFERIDO = LIVROS.GENERO
    GROUP BY AUTORES.CODIGO_AUTOR, AUTORES.GENERO_PREFERIDO) X,(
    SELECT AUTORES.CODIGO_AUTOR AS AUTOR, COUNT(*) AS TOTAL
    FROM LIVROS, AUTORES
    WHERE LIVROS.CODIGO_AUTOR = AUTORES.CODIGO_AUTOR
    GROUP BY AUTORES.CODIGO_AUTOR, AUTORES.GENERO_PREFERIDO) Y
WHERE AUTORES.CODIGO_AUTOR = X.AUTOR(+) AND AUTORES.CODIGO_AUTOR = Y.AUTOR(+);

/* Ex 3 # */
SELECT SUM(UNIDADES_VENDIDAS) AS SOME, EDITORAS.CODIGO_EDITORA
FROM LIVROS, EDITORAS
WHERE LIVROS.CODIGO_EDITORA = EDITORAS.CODIGO_EDITORA
GROUP BY EDITORAS.CODIGO_EDITORA;

SELECT MIN(X.SOMA) AS MINIMO
FROM LIVROS, (
    SELECT SUM(UNIDADES_VENDIDAS) AS SOMA, EDITORAS.CODIGO_EDITORA AS EDITORA, EDITORAS.NOME AS NOME
    FROM LIVROS, EDITORAS
    WHERE LIVROS.CODIGO_EDITORA = EDITORAS.CODIGO_EDITORA
    GROUP BY EDITORAS.CODIGO_EDITORA, EDITORAS.NOME) X
WHERE LIVROS.CODIGO_EDITORA = X.EDITORA;

SELECT AUTORES.CODIGO_AUTOR AS AUTOR, COUNT(*) AS TOTAL
FROM LIVROS, AUTORES
WHERE LIVROS.CODIGO_AUTOR = AUTORES.CODIGO_AUTOR
GROUP BY AUTORES.CODIGO_AUTOR;

SELECT CODIGO_AUTOR, COUNT(*) AS NUM_LIVROSEDITORA
FROM LIVROS, EDITORAS
WHERE LIVROS.CODIGO_EDITORA = EDITORAS.CODIGO_EDITORA
GROUP BY CODIGO_AUTOR
ORDER BY CODIGO_AUTOR ASC;

SELECT DISTINCT 'O autor ' || AUTORES.NOME || ' escreveu ' || Z.NUM_LIVROSEDITORA || ' de ' || Y.TOTAL || ' livros para a editora ' || EDITORAS.NOME AS "Output"
FROM AUTORES, EDITORAS, LIVROS, (
    SELECT MIN(X.SOMA) AS MINIMO
    FROM LIVROS, EDITORAS, (
        SELECT SUM(UNIDADES_VENDIDAS) AS SOMA, EDITORAS.CODIGO_EDITORA AS EDITORA, EDITORAS.NOME AS NOME
        FROM LIVROS, EDITORAS
        WHERE LIVROS.CODIGO_EDITORA = EDITORAS.CODIGO_EDITORA
        GROUP BY EDITORAS.CODIGO_EDITORA, EDITORAS.NOME) X
    WHERE LIVROS.CODIGO_EDITORA = X.EDITORA AND EDITORAS.CODIGO_EDITORA = LIVROS.CODIGO_EDITORA
    GROUP BY EDITORAS.CODIGO_EDITORA) U, (
    SELECT CODIGO_AUTOR, COUNT(*) AS NUM_LIVROSEDITORA
    FROM LIVROS, EDITORAS
    WHERE LIVROS.CODIGO_EDITORA = EDITORAS.CODIGO_EDITORA
    GROUP BY CODIGO_AUTOR) Z, (
    SELECT AUTORES.CODIGO_AUTOR AS AUTOR, COUNT(*) AS TOTAL
    FROM LIVROS, AUTORES
    WHERE LIVROS.CODIGO_AUTOR = AUTORES.CODIGO_AUTOR
    GROUP BY AUTORES.CODIGO_AUTOR) Y
WHERE AUTORES.CODIGO_AUTOR = Z.CODIGO_AUTOR AND LIVROS.CODIGO_AUTOR = AUTORES.CODIGO_AUTOR AND EDITORAS.CODIGO_EDITORA = LIVROS.CODIGO_EDITORA AND AUTORES.CODIGO_AUTOR = Y.AUTOR AND EDITORAS.CODIGO_EDITORA = 3;

/* Ex 4 #1 */
SELECT DISTINCT LIVROS.TITULO AS TITULO, VENDAS.QUANTIDADE
FROM LIVROS, VENDAS, (
    SELECT DISTINCT LIVROS.TITULO, LIVROS.CODIGO_AUTOR, LIVROS.CODIGO_LIVRO AS codLivro
    FROM LIVROS, AUTORES
    WHERE LIVROS.CODIGO_AUTOR = '17' AND LIVROS.GENERO = 'Informática') X, (
    SELECT CLIENTES.CODIGO_CLIENTE AS codCliente
    FROM CLIENTES
    WHERE MORADA LIKE '%Lisboa')Y
WHERE X.codLivro = VENDAS.CODIGO_LIVRO AND VENDAS.CODIGO_CLIENTE = Y.codCliente
AND X.codLivro = LIVROS.CODIGO_LIVRO AND VENDAS.QUANTIDADE = (
    SELECT MAX(VENDAS.QUANTIDADE)
    FROM VENDAS);

/* Ex 5 # */
SELECT DISTINCT CLIENTES.NOME, LIVROS.TITULO
FROM CLIENTES, EDITORAS, VENDAS, LIVROS, (
    SELECT DISTINCT LIVROS.TITULO AS tituloLivros, EDITORAS.NOME AS nomeEditoras
    FROM LIVROS, EDITORAS
    WHERE LIVROS.CODIGO_EDITORA = (
        SELECT EDITORAS.CODIGO_EDITORA
        FROM EDITORAS
        WHERE EDITORAS.NOME = 'FCA - EDITORA') AND
    LIVROS.CODIGO_EDITORA = EDITORAS.CODIGO_EDITORA AND
    LIVROS.GENERO = 'Informática') X, (
    SELECT TO_CHAR(SYSDATE, 'YY-MM-DD') AS currTime
    FROM DUAL)Y, (
    SELECT MAX(VENDAS.DATA_VENDA) AS UltimaData
    FROM VENDAS)Z
WHERE LIVROS.CODIGO_LIVRO = VENDAS.CODIGO_LIVRO AND VENDAS.DATA_VENDA = Z.UltimaData
AND VENDAS.CODIGO_CLIENTE = CLIENTES.CODIGO_CLIENTE;

/* Ex 6 #1 */
SELECT X.VendaSQnt, CLIENTES.NOME
FROM CLIENTES, VENDAS, (
    SELECT SUM(VENDAS.QUANTIDADE) AS VendasQnt, CLIENTES.NOME AS ClientNome
    FROM VENDAS, CLIENTES
    WHERE VENDAS.CODIGO_CLIENTE = CLIENTES.CODIGO_CLIENTE
    GROUP BY CLIENTES.NOME) X, (
    SELECT MAX(SUM(VENDAS.QUANTIDADE)) AS NUMONEFOUR
    FROM VENDAS, CLIENTES
    WHERE CLIENTES.CODIGO_CLIENTE = VENDAS.CODIGO_CLIENTE
    GROUP BY CLIENTES.NOME) Y
WHERE CLIENTES.CODIGO_CLIENTE = VENDAS.CODIGO_CLIENTE AND CLIENTES.NOME = X.CLIENTNOME and X.VENDASQNT = Y.NUMONEFOUR
GROUP BY X.VENDASQNT, clientes.nome;

/* Ex 7 #15 */
SELECT NOME, TITULO, DATA_EDICAO
FROM LIVROS, AUTORES, (
    SELECT CODIGO_AUTOR, MAX(DATA_EDICAO) AS DATAS
    FROM LIVROS
    GROUP BY CODIGO_AUTOR) X
WHERE AUTORES.CODIGO_AUTOR = LIVROS.CODIGO_AUTOR
AND X.CODIGO_AUTOR = AUTORES.CODIGO_AUTOR
AND DATA_EDICAO = DATAS;

/* Ex 8 #10 */
-- IMCOMPLETO
SELECT TO_CHAR(DATA_EDICAO, 'WW') AS SEMANA, LIVROS.TITULO
FROM LIVROS, EDITORAS
WHERE LIVROS.CODIGO_EDITORA = EDITORAS.CODIGO_EDITORA
AND EDITORAS.NOME LIKE 'FCA%'
AND LIVROS.GENERO = 'Informática';

-- COMPLETO #11
SELECT TITULO, SEMANA, MAX(SOMA) AS MAXIMO
FROM EDITORAS, LIVROS, (
    SELECT CODIGO_LIVRO, TO_CHAR(DATA_VENDA, 'WW') AS SEMANA, SUM(QUANTIDADE) AS SOMA
    FROM VENDAS
    GROUP BY CODIGO_LIVRO, TO_CHAR(DATA_VENDA, 'WW')) X
WHERE LIVROS.CODIGO_LIVRO = X.CODIGO_LIVRO
AND EDITORAS.CODIGO_EDITORA = LIVROS.CODIGO_EDITORA
AND GENERO = 'Informática'
AND NOME LIKE 'FCA%'
GROUP BY TITULO, SEMANA;

/* Ex 9 # */
SELECT CIDADE, TITULO
FROM LIVROS, AUTORES, (
    SELECT CODIGO_LIVRO, VENDAS.CODIGO_CLIENTE, MORADA AS CIDADE
    FROM VENDAS, CLIENTES
    WHERE CLIENTES.CODIGO_CLIENTE = VENDAS.CODIGO_CLIENTE
    AND MORADA NOT LIKE '%Paris'
    AND TOTAL_VENDA = (SELECT MAX(TOTAL_VENDA) FROM VENDAS)) X
WHERE LIVROS.CODIGO_LIVRO = X.CODIGO_LIVRO
AND LIVROS.CODIGO_AUTOR = AUTORES.CODIGO_AUTOR
AND NACIONALIDADE = 'Portuguesa'
AND GENERO = 'Informática';
