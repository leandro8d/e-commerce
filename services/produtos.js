app.factory("produtosService", function ($cookies) {
    prod = {};
    prod.list = [
        { Id: 1, Nome: "produto 1", Preco: 325, Img: 'http://www.failwars.blog.br/wp-content/uploads/2013/07/valor-do-playstation-4-no-brasil.jpg', Quantidade: 25 },
        { Id: 2, Nome: "produto 2", Preco: 225, Img: "http://photos1.blogger.com/x/blogger/4305/4288/1600/240822/Mp4%20Sansa%20blog.jpg", Quantidade: 25 },
        { Id: 3, Nome: "produto 3", Preco: 125, Img: "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTgv81Y8rWseCFupx6xxqcI6si1ejd-pYN7JLVOb9WL54e3k_fBOQ", Quantidade: 75 },
        { Id: 4, Nome: "produto 4", Preco: 625, Img: "http://s.glbimg.com/po/tt/f/original/2013/05/08/notebook.jpg", Quantidade: 65 },
        { Id: 5, Nome: "produto 5", Preco: 725, Img: "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSP6BaVjZynGyZN4KL_dMUQ8exGfwzJTALtRNN4l-VFdSbS2Havww", Quantidade: 55 },
        { Id: 6, Nome: "produto 6", Preco: 825, Img: "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcR5vA6Y-VPt27yZ3QsFqQLAmmQU_UfFGvvGNKe_EAigql25BtMu", Quantidade: 5 },
        { Id: 7, Nome: "produto 7", Preco: 925, Img: "http://f.i.uol.com.br/fotografia/2015/05/06/509108-640x480-1.jpeg", Quantidade: 25 }];

    prod.adicionarProduto = function (produto) {
        prod.list.push(produto);
    }
    prod.removerProduto = function (produto) {

        for (var i = 0 in prod.list) {
            if (prod.list[i].Id == produto.Id) {
                prod.list.splice(i, 1);
                break;
            }
        }
    }

    prod.editarProduto = function (produto) {

        for (var i = 0 in prod.list) {
            if (prod.list[i].Id == produto.Id) {
                prod.list[i].Nome = produto.Nome;
                prod.list[i].Preco = produto.Preco;
                prod.list[i].Quantidade = produto.Quantidade;
                prod.list[i].Img = produto.Img;
                break;
            }
        }
    }




    return prod;

});