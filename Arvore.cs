using System;
using System.Collections.Generic;
using System.Text;

namespace ArvoreAVL
{
    public class Arvore
    {
        protected No raiz;

        public void Inserir(int key, int dados)
        {
            if (this.raiz == null)
            {
                this.raiz = new No(key, dados, null);
            }
            else
            {
                this.raiz.Persistir(key, dados);
            }
        }

        public int Delete(int key)
        {
            if (this.raiz.key == key)
            {
                if (this.raiz.filhoEsquerdo == null && this.raiz.filhoDireito == null)
                {
                    var objeto = this.raiz.dados;
                    this.raiz = null;
                    return objeto;
                }
                else if (this.raiz.filhoEsquerdo != null && this.raiz.filhoDireito == null)
                {
                    var objeto = this.raiz.dados;
                    this.raiz = this.raiz.filhoEsquerdo;
                    this.raiz.noPai = null;
                    return objeto;
                }
                else if (this.raiz.filhoEsquerdo == null && this.raiz.filhoDireito != null)
                {
                    var objeto = this.raiz.dados;
                    this.raiz = this.raiz.filhoDireito;
                    this.raiz.noPai = null;
                    return objeto;
                }
                else
                {
                    var sucessor = this.raiz.Sucessor();
                    var objeto = raiz.dados;
                    this.Delete(sucessor.key);
                    this.raiz.key = sucessor.key;
                    this.raiz.dados = sucessor.dados;
                    return objeto;
                }
            }
            else
            {
                No node = this.raiz.Consultar(key);
                var objeto = node.dados;
                if (node.filhoEsquerdo == null && node.filhoDireito == null)
                {
                    if (node.noPai.filhoEsquerdo.key == node.key)
                    {
                        node.noPai.filhoEsquerdo = null;
                    }
                    else
                    {
                        node.noPai.filhoDireito = null;
                    }
                    return objeto;
                }
                else if (node.filhoEsquerdo != null && node.filhoDireito == null)
                {
                    if (node.noPai.filhoEsquerdo.key == node.key)
                    {
                        node.noPai.filhoEsquerdo = node.filhoEsquerdo;
                    }
                    else
                    {
                        node.noPai.filhoDireito = node.filhoEsquerdo;
                    }
                    return objeto;
                }
                else if (node.filhoEsquerdo == null && node.filhoDireito != null)
                {
                    if (node.noPai.filhoDireito.key == node.key)
                    {
                        node.noPai.filhoDireito = node.filhoDireito;
                    }
                    else
                    {
                        node.noPai.filhoEsquerdo = node.filhoDireito;
                    }
                    return objeto;
                }
                else if (node.filhoEsquerdo != null && node.filhoDireito != null)
                {
                    var sucessor = node.Sucessor();
                    objeto = node.dados;
                    this.Delete(sucessor.key);
                    node.key = sucessor.key;
                    node.dados = sucessor.dados;
                    return objeto;
                }
                else
                {
                    if (node.noPai.filhoDireito.key == node.key)
                    {
                        node.noPai.filhoDireito = null;
                    }
                    else
                    {
                        node.noPai.filhoEsquerdo = null;
                    }
                    return objeto;
                }
            }
        }

        public No Consultar(int key)
        {
            return this.raiz.Consultar(key);
        }

        public void VerificarBalanceamento(No atual)
        {
            setBalanceamento(atual);
            var balanceamento = atual.getBalanceamento();

            if(balanceamento == -2)
            {
                if(atual.getAltura(atual.filhoEsquerdo.filhoEsquerdo) >= atual.getAltura(atual.filhoEsquerdo.filhoDireito))
                {
                    Console.WriteLine("A árvore ta desbalanceada e receberá rotação simples para a direita");
                    atual = RotacaoSimplesDireita(atual);
                }
                else
                {
                    Console.WriteLine("A árvore ta desbalanceada e receberá rotação dupla para a esquerda");
                    atual = DuplaRotacaoEsquerdaDireita(atual);
                }
            }
            else if (balanceamento == 2)
            {
                if(atual.getAltura(atual.filhoDireito.filhoDireito) >= atual.getAltura(atual.filhoDireito.filhoEsquerdo))
                {
                    Console.WriteLine("A árvore ta desbalanceada e receberá rotação simples para a esquerda");
                    atual = RotacaoSimplesEsquerda(atual);
                }
                else 
                {
                    Console.WriteLine("A árvore ta desbalanceada e receberá rotação dupla para a direita");
                    atual = DuplaRotacaoDireitaEsquerda(atual);
                }
            }

            if(atual.noPai != null)
            {
                VerificarBalanceamento(atual.noPai);
            }
            else
            {
                this.raiz = atual;
            }
        }

        public No RotacaoSimplesDireita(No inicial)
        {
            No esquerda = inicial.filhoEsquerdo;
            esquerda.noPai = inicial.noPai;

            inicial.filhoEsquerdo = inicial.filhoDireito;

            if(inicial.filhoEsquerdo != null)
            {
                inicial.filhoEsquerdo.noPai = inicial;
            }

            esquerda.filhoDireito = inicial;
            inicial.noPai = esquerda;

            if(esquerda.noPai != null)
            {
                if(esquerda.noPai.filhoDireito == inicial)
                {
                    esquerda.noPai.filhoDireito = esquerda;
                }
                else if(esquerda.noPai.filhoEsquerdo == inicial)
                {
                    esquerda.noPai.filhoEsquerdo = esquerda;
                }
            }

            setBalanceamento(inicial);
            setBalanceamento(esquerda);

            return esquerda;
        }

        public No RotacaoSimplesEsquerda(No inicial)
        {
            No direita = inicial.filhoDireito;
            direita.noPai = inicial.noPai;

            inicial.filhoDireito = direita.filhoEsquerdo;

            if(inicial.filhoDireito != null)
            {
                inicial.filhoDireito.noPai = inicial;
            }

            direita.filhoEsquerdo = inicial;
            inicial.noPai = direita;

            if(direita.noPai != null)
            {
                if(direita.noPai.filhoDireito == inicial)
                {
                    direita.noPai.filhoDireito = direita;
                }
                else if( direita.noPai.filhoEsquerdo == inicial)
                {
                    direita.noPai.filhoEsquerdo = direita;
                }
            }

            setBalanceamento(inicial);
            setBalanceamento(direita);

            return direita;
        }

        public No DuplaRotacaoEsquerdaDireita(No inicial)
        {
            inicial.filhoEsquerdo = RotacaoSimplesEsquerda(inicial.filhoEsquerdo);

            return RotacaoSimplesDireita(inicial);
        }

        public No DuplaRotacaoDireitaEsquerda(No inicial)
        {
            inicial.filhoDireito = RotacaoSimplesDireita(inicial.filhoDireito);
            return RotacaoSimplesEsquerda(inicial);
        }

        public void setBalanceamento(No no)
        {
            no.setBalanceamento(no.getAltura(no.filhoDireito) - no.getAltura(no.filhoEsquerdo));
        }
    }
}
