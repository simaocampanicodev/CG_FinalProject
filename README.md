# Relatório

## Tema: Distortion Effect (Unity)

### 30/12/25
Comecei por fazer uma pesquisa no Youtube sobre o uso do Distortion Effect, e pude reparar que o mesmo era bastante usado em edições de vídeo como Affter Effects e Premiere Pro, mas eu queria saber também sobre a utilização nos jogos, e encontrei um shorts que fala sobre esse efeito no jogo Valorant, que é o meu jogo favorito.
Procurando mais sobre, descobri que esse efeito é muito falado na comunidade de jogos devido à queda de FPS que esse efeito ativado pode trazer, que, no caso de Valorant, é cerca de 23,5%, como referido no vídeo: https://www.youtube.com/shorts/RUV1_B3z2Ww.

### 31/12/25
Continuando a pesquisa e procurando por onde começar, encontrei no Unity Discussions pessoas a falar sobre como fazer
distortion effect. Felizmente alguém respondeu com uma maneira de o fazer usando o URP, que seria usando o Scene Color Shader Graph node. Toda essa explicação está no comentário de como o fazer, e eu, fui experimentar se conseguia seguir esse "passo-a-passo" e
ver o efeito. O link para o Unity Discussions referido: https://discussions.unity.com/t/how-to-make-a-distorting-effect/250474.

Porém, antes de tudo isso, necessito de criar uma cena que me permita realmente ver esse efeito.

### 02/01/2026

Decidi mudar um pouco de ideias e usei um PlayerMovement.cs de um projeto antigo para poder progredir com a ideia de fazer uma sala em que o Player vai poder andar, que seja bastante simples e apenas para se verificar o efeito. Adicionei o PlayerMovement a um CapsuleCollider e criei um script the PlayerLook baseado no vídeo: https://www.youtube.com/watch?v=_QajrabyTJc. Defini a câmara principal como filha do objeto Player, para a rotação e o movimento ser automáticos e dei freeze na rotação do X e do Z no RigidBody para o Player não simplesmente cair. (Primeiramente esqueci-me de dar freeze, e assustei-me com o boneco a deitar-se no chão e a rebolar). Também mudei o Interpolate de None para Interpolate e meti a Collision Detection em Continuous e testei para ver se estava tudo certo. A câmara tem os limites que eu meti para cima e para baixo, ou seja, não passa de 90 e -90 respetivamente então está tudo como eu quero por agora. Em seguida, pensei em criar uma sala simples, e para isso, decidi

_Simão Campaniço a22510616_
