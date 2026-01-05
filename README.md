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

### 04/01/2026

O meu primeiro passo agora foi criar um shader para o DistortionEffect, e inicialmente vi e decidi usar o método `OnRenderImage` (https://docs.unity3d.com/6000.3/Documentation/ScriptReference/MonoBehaviour.OnRenderImage.html). Criei um Shader HLSL chamado FullScreenDistortion que distorcia as coordenadas UV da texture usando o seno junto com intensity e frequency para fazer as ondas da distorção. Ele usa a textura \_MainTex e com o método `OnRenderImage` a imagem era renderizada pela camâra. Depois disso, criei um Material a partir desse shader chamado `DistortionMat`. Após isso, criei um script chamado `DistortionController` (https://docs.unity3d.com/6000.3/Documentation/ScriptReference/Graphics.Blit.html) à Main Camera para aplicar o `DistortionMat`, mas não funcionava nada. Perguntei ao ChatGPT o que poderia ter ocorrido e, quando verifiquei as configurações do projeto eu percebi que quando mudava para (Built-in) o Unity mostrava: "A Scriptable Render Pipeline is in use. Settings in the Built-In Render Pipeline are not currently in use", e quando fui novamente ao site do `OnRenderImage` eu descobri que o método não é suportado em URP, que é o Render Pipeline em que o projeto foi criado, e era por isso que o shader não funcionava.
Quando me apercebi disso, fui fazer uma pesquisa melhor, para apenas me aparecer maneiras de o fazer com URP e encontrei um vídeo ideal (https://www.youtube.com/watch?v=MaVmsOF4pXY) e decidi testar para ver se funcionava.
Comecei por criar um FullScreen Shader Graph e o seu respetivo material. Depois disso fui ao Universal Renderer Data e adicionei uma Renderer Feature de `Full Screen Pass` e mudei o material para o Pass Material. Ao fazer isso, o ecrã fica completamente cinzento, que é normal, porque a Base Color do Shader Graph é cinzento. Para mudar isso, apenas adicionei um `Scene Color node` e alterei a Base Color por ela. Depois, criei um `UV node` e liguei-o a um `Lerp node` para ele dar "interpolate" da entrada A (UV) com a entrada B (`Simple Noise node`) baseado no valor T (que é o nosso float Blend).
Criei um float chamado NoiseScale com um valor default de 10 que será a escala do Simple Noise, e após isso já posso ligar o Lerp ao UV da `Scene Color node`. Só com isso, já é possível ver um efeito de Distortion se mudarmos o valor do NoiseScale e do Blend, mas o objetivo é que esse Noise que vem do `Simple Noise node` faça scrolling, ou seja, fique a mexer-se durante o tempo. Para isso, comecei por criar um `Tiling And Offset node` e ligar o Output dele ao UV do `Simple Noise node`. Depois, criei um `Time node` e um Vector2 chamado PanSpeed e multipliquei o Time por esse PanSpeed, e esse valor final será o Offset do `Tiling And Offset node`, porém, agora a distorção acontece só para uma direção, e o objetivo é que ela aconteça para a frente e para trás, e para isso eu criei uma propriedade de Amplitude e liguei o Output da multiplicação a um `Sine node`, que faz estar a ir de -1 a 1 e liguei o Output dela a uma multiplicação entre o `Sine node` e a Amplitude, e agora sim liguei o Output dessa multiplicação ao Offset do `Tiling And Offset node`.
Após isso, testei o jogo e notei que os valores estavam demasiado elevados, e que a distorção era demasiado, então alterei os valores até encontrar uma distorção que me agradace, e funcionou.
Agora é possível andar pela ilha e observar o DistortionEffect a acontecer, seja na ilha, na ponte, na água ou especialmente na casa em frente ao jogador.
Para finalizar, eu quero testar se é possível só usar o FullScreen Shader em certas cenas, ou seja, tentar por código desativar e ativar o shader por cena.

## Licenças

Modelo 3D “House in the Sea” utilizado sob licença Personal Use License.
Criado por dudehtm.
Disponível em: https://free3d.com/3d-model/house-in-the-beach-659371.html

Skybox “Skybox 28” utilizada sob Royalty Free License (permitido o uso comercial e não-comercial).
Gen AI used combined with Traditional Painting Methods in creation of all Skybox.
Disponível em: https://freestylized.com/skybox/sky_28/

_Simão Campaniço a22510616_
