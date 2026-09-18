# **GDD \-  Inipulo**

 

## *1\. Resumo Executivo*

* Título do Jogo: CapiJump 
* Gênero: Plataforma vertical / Climbing Platformer  
* Plataformas: PC, Mobile  
* Público-alvo: Jogadores casuais de todas idades  
* Descrição Geral: Um jogo casual e dinâmico de subida por fases, onde o jogador precisa saltar estrategicamente entre plataformas para alcançar o topo do mapa, desviando de perigos ambientais e coletando moedas para desbloquear skins cosméticas  
* Objetivos: Alcançar o ponto/objetivo definido no topo da fase.


2. ## *Visão Geral do Jogo*

* Estória/Enredo:   
  * Premissa: O jogador deve controlar o personagem em um ambiente de rolagem vertical até chegar ao topo.  
  * Ambientação: A decidir.  
  * Personagens: Um único personagem jogável.  
* Mecânicas de jogo:  
  * Gameplay Core: O personagem salta para cima ao pressionar a tecla "espaço" ou tocar na tela.  
  * Progressão: Terão obstáculos e power-ups conforme o nível prosseguir.  
  * Desafios: A quantidade de obstáculos aumenta ao escalar o nível.  
* Estilo Visual:  
  * Referências Visuais: A decidir  
  * Paleta de Cores: A decidir  
* Estilo Sonoro:  
  * Música: Música de fundo simples royalty free  
  * Efeitos Sonoros: Sons ao pular, colidir com obstáculo, pegar power-up, utilizar power-up e chegar ao topo.

3. ## *Mecânicas de Jogo*

* Controles:   
  * Mapeamento de Controles:  
* Interações: 3 itens espalhados pelo mapa, 2 itens de buff proporcionado uma armadura e o outro um super jump, o outro item seria um debuff gerando efeitos negativos pelo mapa (ex: chuva de fogo, espinhos pelo mapa )   
* Sistemas de Jogo:  
  * Combate: não tem combate  
  * Inventário:não tem inventário, os power up são guardados para ser usado quando player precisa  
  * Economia:   
  * Personalização: Progressão de pegar moedas para conseguir skin e quando mapa Estiver com Efeitos negativos aprimorar quantidade De moedas que aparecem e após efeito do mapa Progressão de moeda voltam normal  
    * Skin além da capivara: onça e boto-cor-de rosa e mula sem Cabeça e boitatá e 

##### **![Diagrama do Core Loop](docs/diagrama-core-loop.png)Diagrama do Core Loop**

4. ## *Níveis e Ambientes*

* Design de Níveis:2 Níveis  
  * Estrutura Geral:  	  
  * Pacing: Início calmo com plataformas fixas largas, evoluindo para plataformas móveis, quebradiças e eventos de debuff em frequências mais curtas   
* Ambientes:   
  * Descrição dos cenários: Céu no background \+ elementos do nível (plataformas, obstáculos e power-ups)  
  * Interatividade: Física de colisão com plataformas e obstáculo, mecânica de aquisição de power-ups 

![mapsketchparte2](docs/mapsketchparte2.png)

![mapsketch](docs/mapsketch.png)

**Rascunho do mapa**

![cenário floresta](artejogo/cenario/descrição%20cenario%20floresta.png)

5. ## *Inteligência Artificial (IA)*

* Comportamento dos NPCs:  O jogo não utiliza NPCs complexos 	  
* Adaptabilidade: A frequência de surgimento de obstáculos e o tipo de debuff ajustam-se com base na altura atual alcançada pelo jogador 

6. ## *Interface do Usuário (UI)*

* HUD (Heads-Up Display):    
  * Contador de Moedas    
  * Ícone do Power-up    
  * Marcador de Altura/Progresso  
* Menus:  Ter 3 botões um para iniciar e outro para sair e outro para lojinha das skin  
* Feedback Visual/Sonoro:

7. ## *Arte e Animação*

* Modelos 3D/Sprites: Sprites 2D simples para personagem e skins, plataformas e obstáculos  
* Animação:   
  * Personagem parado/pulando   
  * Queda e dano.   
  * Plataforma e obstáculos se movendo  
* Cinemáticas: Não se aplica

![Capivara Spriteshhet](artejogo/personagemprincipal/model%20sheet%20capivara.png)

![objectpack](artejogo/plataformaseobjetos/objectpack.png)

**Pack de sprite Pixel Platform de Kenney**

8. ## *Sons e Música*

* Trilha Sonora:   
* Efeitos Sonoros:   
  * Pulo / Super Pulo   
  * Coleta de Moeda    
  * Ativação de Armadura    
  * Impacto / Dano   
  * Vitória ao atingir o top  
* Mixagem de Áudio: a decidir

9. ## *Monetização (se aplicável)*

* Modelo de Negócio: Free-topl  
* Microtransações: Free-to-Play   
* Publicidade: Sem anúncio 

10. ## *Análise de Risco*

* Desafios Técnicos: Randomização de obstáculos, manter dificuldade balanceada  
* Plano de Mitigação: Pesquisar viabilidade e implementação de randomização de obstáculos, testar jogabilidade para balanceamento de dificuldade

11. ## *Cronograma e Planejamento*

* Fases do Desenvolvimento:  
  * Pré-produção: 2 semanas  
  * Produção: 4 semanas  
  * Pós-produção: 1 semana  
* Marcos:  
  * Protótipo funcional: Em 3 semanas  
  * Arte e som implementados: Em 4 semanas  
  * Testes de jogabilidade: Em 5 semanas  
  * Refinamento e lançamento: Em 6 semanas  
* Recursos Necessários: Sprites, Trilha e efeitos sonoros, imagem de background

12. ## *Apêndice*

* Referências: Doodle Jump como principal inspiração  
* Anexos: 

![DoddleJump1](docs/anexos/image2.png)![DoodleJump2](docs/anexos/image1.png)

## *Créditos dos assets*

* Cenário: [Arte de Saurabhkgp](https://saurabhkgp.itch.io/pixel-art-forest-background-simple-seamless-parallax-ready-for-2d-platformer-s) (via [itch.io](http://itch.io))  
* Interface de Usuário: [Arte por Kenney](https://kenney-assets.itch.io/ui-pack) (via [itch.io](http://itch.io))  
* Personagem: [Arte por Rainloaf](https://rainloaf.itch.io/capybara-sprite-sheet) (via [itch.io](http://itch.io))  
* Plataformas e Objetos: [Arte por Kenney](https://kenney.nl/assets/pixel-platformer) (via [itch.io](http://itch.io))