# Relatório - Computação Gráfica

## Tema: Distortion Effect (Unity)

## Timeline

### 30/12/25

Comecei por fazer uma pesquisa no Youtube sobre o uso do Distortion Effect, e pude reparar que o mesmo era bastante usado em edições de vídeo como Affter Effects e Premiere Pro, mas eu queria saber também sobre a utilização nos jogos, e encontrei um shorts que fala sobre esse efeito no jogo Valorant, que é o meu jogo favorito.
Procurando mais sobre, descobri que esse efeito é muito falado na comunidade de jogos devido à queda de FPS que esse efeito ativado pode trazer, que, no caso de Valorant, é cerca de 23,5%, como referido no vídeo: https://www.youtube.com/shorts/RUV1_B3z2Ww.

### 31/12/25

Continuando a pesquisa e procurando por onde começar, encontrei no Unity Discussions pessoas a falar sobre como fazer
distortion effect. Felizmente alguém respondeu com uma maneira de o fazer usando o URP, que seria usando o Scene Color Shader Graph node. Toda essa explicação está no comentário de como o fazer, e eu, fui experimentar se conseguia seguir esse "passo-a-passo" e
ver o efeito. O link para o Unity Discussions referido: https://discussions.unity.com/t/how-to-make-a-distorting-effect/250474.

Porém, antes de tudo isso, necessito de criar uma cena que me permita realmente ver esse efeito.

### 02/01/2026

Decidi mudar um pouco de ideias e usei um PlayerMovement.cs de um projeto antigo para poder progredir com a ideia de fazer uma sala em que o Player vai poder andar, que seja bastante simples e apenas para se verificar o efeito. Adicionei o PlayerMovement a um CapsuleCollider e criei um script the PlayerLook baseado no vídeo: https://www.youtube.com/watch?v=_QajrabyTJc. Defini a câmara principal como filha do objeto Player, para a rotação e o movimento ser automáticos e dei freeze na rotação do X e do Z no RigidBody para o Player não simplesmente cair. (Primeiramente esqueci-me de dar freeze, e assustei-me com o boneco a deitar-se no chão e a rebolar). Também mudei o Interpolate de None para Interpolate e meti a Collision Detection em Continuous e testei para ver se estava tudo certo. A câmara tem os limites que eu meti para cima e para baixo, ou seja, não passa de 90 e -90 respetivamente então está tudo como eu quero por agora. Em seguida, pensei em criar uma sala simples. Fui analisar também o GitHub para ter noção de como estavam as formatações do README.md e deparei-me com 65% de "Mathematica", que não percebi o que era. Ao pesquisar na aba normal do Google apareceu que isso é um erro comum a detetar os materiais .mat como "Mathematica", algo que não acontece, e dizia para adicionar "\*.mat linguist-vendored" no .gitattributes para resolver isso, mas eu fiz e não resolveu. Decidi perguntar ao ChatGPT a especificar o que eu já tinha feito e disse-me que era um erro comum e que o .gitattributes não atualiza automaticamente com os commits no GitHub, e que devo esperar 24-48h, então deixei isso de parte e comecei a pesquisa por casas para meter no mapa, e encontrei uma ilha simples que decidi usar para poder testar o efeito:https://free3d.com/3d-model/house-in-the-beach-659371.html. Fiz download, arrastei o ficheiro .fbx e a textura da água e meti na cena. Ajustei os tamanhos, tive que diminuir o Player porque ele era demasiado grande para o tamanho da casa que estava na ilha e comecei a meter os colliders. Comecei por testar só os colliders no chão e na pequena ponte que a ilha tem e reparei que quando o Player colidia contra ela a câmara ficava a girar infinitamente, o que eu inicialmente não entendi muito bem, e quando pesquisar no Google apareceu a Unity Documentation do angularDamping (https://docs.unity3d.com/6000.3/Documentation/ScriptReference/Rigidbody-angularDamping.html), que eu testei inserir no meu script do PlayerMovement para ver se solucionava, e realmente solucionou essa rotação estranha, mas agora cada vem que eu ia contra um collider ligeiramente "de lado" a câmara tentava sempre se alinhar, e isso era bastante estranho, ainda mais quando ia contra as paredes da casa ou mesmo quando ia contra a borda da ilha de costas, o que me fez voltar àquele vídeo do Youtube do Brackeys e ver como ele fazia o PlayerMovement, e aí deu-me logo o click de em vez de utilizar RigidBody usar o Character Controller, que além de ser mais fácil e simples, resolvia todos esses problemas que eu estava a ter com as colisões nas paredes. Após alterar o código e adicionar a componente do Character Controller esse problema desapareceu.
Após adicionar todos os colliders e agrupá-los num Empty Object decidi procurar uma SkyBox simples, que facilmente encontrei no site: https://freestylized.com/skybox/sky_28/. Com tudo alinhado e com o mapa definido e o movimento do Player, estava na altura de criar o DistortionEffect, que é a parte mais importante.

_Simão Campaniço a22510616_
