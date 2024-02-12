--
-- PostgreSQL database dump
--

-- Dumped from database version 13.3
-- Dumped by pg_dump version 13.3

-- Started on 2024-02-12 21:43:24

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

DROP DATABASE booksystem;
--
-- TOC entry 3091 (class 1262 OID 1244241)
-- Name: booksystem; Type: DATABASE; Schema: -; Owner: postgres
--

CREATE DATABASE booksystem WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE = 'Russian_Russia.1251';


ALTER DATABASE booksystem OWNER TO postgres;

\connect booksystem

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

--
-- TOC entry 3 (class 2615 OID 2200)
-- Name: public; Type: SCHEMA; Schema: -; Owner: postgres
--

CREATE SCHEMA public;


ALTER SCHEMA public OWNER TO postgres;

--
-- TOC entry 3092 (class 0 OID 0)
-- Dependencies: 3
-- Name: SCHEMA public; Type: COMMENT; Schema: -; Owner: postgres
--

COMMENT ON SCHEMA public IS 'standard public schema';


SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- TOC entry 203 (class 1259 OID 1244251)
-- Name: authors; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.authors (
    author_id integer NOT NULL,
    author_name text NOT NULL
);


ALTER TABLE public.authors OWNER TO postgres;

--
-- TOC entry 202 (class 1259 OID 1244249)
-- Name: authors_author_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

ALTER TABLE public.authors ALTER COLUMN author_id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public.authors_author_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- TOC entry 201 (class 1259 OID 1244244)
-- Name: books; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.books (
    book_id integer NOT NULL,
    genre_id integer NOT NULL,
    author_id integer NOT NULL,
    book_name text NOT NULL,
    book_description text,
    publisher_id integer NOT NULL,
    series_id integer NOT NULL,
    book_publish_year integer,
    book_pages integer,
    book_price integer DEFAULT 0 NOT NULL
);


ALTER TABLE public.books OWNER TO postgres;

--
-- TOC entry 200 (class 1259 OID 1244242)
-- Name: books_book_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

ALTER TABLE public.books ALTER COLUMN book_id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public.books_book_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- TOC entry 217 (class 1259 OID 1301690)
-- Name: carts; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.carts (
    user_id integer NOT NULL,
    book_id integer NOT NULL,
    primary_id integer NOT NULL,
    cart_values integer DEFAULT 1 NOT NULL
);


ALTER TABLE public.carts OWNER TO postgres;

--
-- TOC entry 216 (class 1259 OID 1301688)
-- Name: carts_primary_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

ALTER TABLE public.carts ALTER COLUMN primary_id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public.carts_primary_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- TOC entry 205 (class 1259 OID 1244258)
-- Name: genres; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.genres (
    genre_id integer NOT NULL,
    genre_name text NOT NULL
);


ALTER TABLE public.genres OWNER TO postgres;

--
-- TOC entry 204 (class 1259 OID 1244256)
-- Name: genres_genre_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

ALTER TABLE public.genres ALTER COLUMN genre_id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public.genres_genre_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- TOC entry 207 (class 1259 OID 1244321)
-- Name: publishers; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.publishers (
    publisher_id integer NOT NULL,
    publisher_name text NOT NULL
);


ALTER TABLE public.publishers OWNER TO postgres;

--
-- TOC entry 206 (class 1259 OID 1244319)
-- Name: publishers_publisher_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

ALTER TABLE public.publishers ALTER COLUMN publisher_id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public.publishers_publisher_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- TOC entry 215 (class 1259 OID 1293504)
-- Name: roles; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.roles (
    role_id integer NOT NULL,
    role_name text NOT NULL,
    role_is_admin boolean NOT NULL
);


ALTER TABLE public.roles OWNER TO postgres;

--
-- TOC entry 214 (class 1259 OID 1293502)
-- Name: roles_role_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

ALTER TABLE public.roles ALTER COLUMN role_id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public.roles_role_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- TOC entry 209 (class 1259 OID 1252513)
-- Name: series; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.series (
    series_id integer NOT NULL,
    series_name text NOT NULL
);


ALTER TABLE public.series OWNER TO postgres;

--
-- TOC entry 208 (class 1259 OID 1252511)
-- Name: series_series_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

ALTER TABLE public.series ALTER COLUMN series_id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public.series_series_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- TOC entry 211 (class 1259 OID 1293473)
-- Name: users; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.users (
    user_id integer NOT NULL,
    user_login text NOT NULL,
    user_password text NOT NULL,
    user_register_date timestamp without time zone DEFAULT CURRENT_TIMESTAMP NOT NULL,
    role_id integer NOT NULL
);


ALTER TABLE public.users OWNER TO postgres;

--
-- TOC entry 213 (class 1259 OID 1293485)
-- Name: users_books; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.users_books (
    ub_id integer NOT NULL,
    user_id integer NOT NULL,
    book_id integer NOT NULL,
    ub_add_date timestamp without time zone DEFAULT CURRENT_TIMESTAMP NOT NULL
);


ALTER TABLE public.users_books OWNER TO postgres;

--
-- TOC entry 212 (class 1259 OID 1293483)
-- Name: users_books_ub_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

ALTER TABLE public.users_books ALTER COLUMN ub_id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public.users_books_ub_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- TOC entry 210 (class 1259 OID 1293471)
-- Name: users_user_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

ALTER TABLE public.users ALTER COLUMN user_id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public.users_user_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- TOC entry 3071 (class 0 OID 1244251)
-- Dependencies: 203
-- Data for Name: authors; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.authors (author_id, author_name) FROM stdin;
1	Майк Омер
2	Роберт Джордан
3	Дженнифер Линн Барнс
5	uipo[oiuyt
6	Александра Сутямова
7	Марина Горштейн
8	Без автора
9	Василий Ключевский
10	Иосиф Линдер
11	Джоан Кэтлин Роулинг
12	Елена Бурцева
13	Руслан Чумак
14	Людмила Великова
15	Алла Боголепова
\.


--
-- TOC entry 3069 (class 0 OID 1244244)
-- Dependencies: 201
-- Data for Name: books; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.books (book_id, genre_id, author_id, book_name, book_description, publisher_id, series_id, book_publish_year, book_pages, book_price) FROM stdin;
7	2	2	Колесо Времени. Книга 6. Властелин хаоса	Среди сообщества Айз Седай раскол. Признать Ранда ал’Тора Возрожденным Драконом или заклеймить его как самозванца? Темный властелин все силы прикладывает к тому, чтобы убедить Престол Амерлин в том, что Ранд — Лжедракон. Он внедряет в ряды Айз Седай своих приспешниц, наделяя их новыми телами, и плетет интригу за интригой. Мало того, Темный наводит на мир засуху и безумную жару, представляя все это происками Лжедракона Ранда ал’Тора. Найнив и Илэйн, оставившие Белую Башню после переворота, пускаются в долгий путь, чтобы отыскать истину…	1	1	4	4	1359
11	2	3	1235	123456	2	1	5	5	599
3	1	3	Последний гамбит	Все, что осталось Эйвери Грэмбс сделать, чтобы получить наследство – прожить несколько недель в особняке Хоторнов до своего совершеннолетия. Но это не так-то просто, ведь с каждым днем напряжение нарастает. Папарацци преследуют ее на каждом шагу, и ее жизни постоянно грозит опасность. Только поддержка братьев помогает Эйвери все это выдержать. Она считала, что раскрыла все тайны семьи Хоторнов, пока на пороге ее дома внезапно не появился незваный гость. Осталось решить последнюю загадку. Эйвери и братьям вновь предстоит сразиться с могущественным противником. На этот раз на кон поставлено все. Игра началась.	1	1	6	6	619
1	1	1	Тринадцатая карта	Детективы Ханна Шор и Бернард Глэдвин начинают расследование смерти Жаклин Мьюн, погибшей от двух пулевых ранений. Но то, что поначалу выглядит случайной стрельбой в неблагополучном районе, оказывается намного сложнее. Жаклин была экстрасенсом, предсказательницей судьбы и знахаркой, гадала на картах Таро и продавала экзотические снадобья, травы и масла. И очень много у кого вокруг были причины желать ее смерти.\r\nГадалка не смогла прочесть свое будущее по картам. Теперь детективам предстоит заглянуть в ее прошлое и выяснить личность загадочного убийцы…	1	1	2	2	469
14	2	6	Нефритовый тигр	Древний Китай. Пять государств, что некогда были единым целым. Для Соны все это чуждо, но она оказалась втянута в войну двух династий, военные заговоры и дворцовые интриги. Ей предстоит распутать клубок истории и полностью переосмыслить прошлое. Может ли она доверять своим знаниям, окружающим ее странным людям или хотя бы самой себе? Так ли живет и дышит этот древний мир, как она себе представляла? И что за судьбу уготовил ей загадочный Белый бог, о котором она ничего не знает?	1	1	2023	320	599
2	2	2	Колесо Времени. Книга 10. Перекрестки сумерек	В мире царят хаос и всеобщее недоверие. В раздоре и пожарах войны страны и континенты. Многим очевидно, что грядет Последняя битва с Темным, решающая для судьбы человечества, и в ней на стороне Света должен выступить Дракон Возрожденный. Но остается загадкой — что он задумал, что предпримет и где затаились его враги…\r\nЭгвейн, возведенная на Престол Амерлин теми из Айз Седай, что отказались признать Элайду, нынешнюю Амерлин в Белой Башне, встала с армией под стенами Тар Валона и грозит силой отобрать у Элайды власть… .\r\nИлэйн Траканд в Кэймлине, столице Андора, ведет борьбу за трон своей матери, стремясь заручиться поддержкой сторонников и отбить посягательства претендентки, которая, вступив в коалицию со знатными лордами королевства, взяла город в осаду…\r\nСам же Ранд, Дракон Возрожденный, в преддверии неминуемой схватки с Темным, стоит на пороге тяжелейшего выбора: заключать или нет перемирие с шончан, ведь сражаться одновременно с вторгшимися из-за океана захватчиками и с Тенью себе дороже…\r\nА еще — и это пугает всех, независимо от политических предпочтений — произошел чудовищный выброс Силы, последствия которого не знает никто…\r\nВ настоящем издании текст романа заново отредактирован и исправлен.	3	1	1	1	1249
12	1	2	123123	123123123	5	1	2023	338	599
5	2	2	Колесо Времени. Книга 8. Путь кинжалов: роман	Монархи Пограничных земель, собрав войска и по древнему обычаю дав взаимную клятву, отправляются походом на юг, чтобы разобраться с Рандом ал’Тором, который взбаламутил полмира и объявил себя Возрожденным Драконом.\r\nТем временем Илэйн и Найнив, заполучив Чашу Ветров и заключив сделку с Морским народом, собираются избавить страну от безумной жары и засухи, наведенных Темным.\r\nПоложение поистине безысходное. Эбу Дар, важнейший морской порт континента, захватили явившиеся с моря шончанские войска и идут теперь с боями на Иллиан.\r\nРанд ал’Тор вступает в схватку с врагом. Но почему саидин, часть силы, которая правит Вселенной и вращает Колесо Времени, не подчиняется его воле, а Калландор, меч, который дается в руки только истинному Дракону, разит всех подряд — и чужих, и своих?..\r\nВ настоящем издании текст романа заново отредактирован и исправлен.	1	1	7	9	1249
6	2	2	Колесо Времени. Книга 4. Восходящая Тень	Ранд ал’Тор, наконец-то завладевший созданным в древности мечом Калландором, который наделяет его обладателя невиданной силой, объявлен Драконом Возрожденным.\r\nИсполнилось одно из пророчеств, явился тот, кто призван спасти народы от Темного, источника и породителя хаоса. Но возрождение Дракона-спасителя создает не только новые нити в плетении мирового Узора, оно притягивает к Ранду ал’Тору пузыри зла, и Ранд становится мишенью для темных сил. Сам мир меняется резко, рвутся родственные связи, распадаются союзы, воины из Айильской пустыни захватывают Тирскую Твердыню, а в Белой Башне города Тар Валон происходит кровавый переворот. И есть много таких людей, кто не готов признавать за Рандом его новую ипостась, и эти люди опасны не менее прислужников Темного.\r\nВ настоящем издании текст романа «Дракон Возрожденный», как и в других романах, составивших знаменитую эпопею «Колесо Времени», заново отредактирован и исправлен.	1	1	3	3	1359
8	2	2	Колесо Времени. Книга 9. Сердце зимы	Ранд ал’Тор, объявивший себя Возрожденным Драконом, скрываясь от прислужников Темного, собирается нанести ответный удар по Тени. В Белой Башне Тар Валона раскол: предательницы из Черных Айя готовят заговор, ну а друзья Ранда озабочены делами насущными. Перрин желает лишь одного — вырвать свою жену из айильского плена. Илэйн стремится уберечь от пожара войны родную страну. Мэт оказался в городе, захваченном явившейся из-за океана шончанской армией, и там судьба сводит его с Дочерью Девяти Лун, которая, как предначертано, должна стать его женой. И никому не ведомо, что ждет их всех впереди... В настоящем издании текст романа заново отредактирован и исправлен.	1	1	8	7	1249
15	4	7	Искусство вязания шали: вдохновение сибирского леса, 12 авторских проектов со схемами для вязания на спицах	«Сибирская сойка», «Птицелов», «Сон-трава», «Марьин корень» — даже просто читая названия, чувствуешь смолистый запах кедровых шишек, шелк полевых трав под ногами, а лучи солнца с трудом прорываются сквозь высоченные кроны деревьев замысловатыми бликами. Чистота, ясность, многогранность, свежесть... Вся прелесть сибирской природы, порой слегка брутальной, а порой — сама нежность, в работах замечательного российского дизайнера Марины Горштейн!\r\n12 роскошных авторских шалей самых разных форм и моделей, связанных спицами с огромной любовью к сибирской природе. Формы шалей разнообразны: классическая треугольная, полукруглая, с горизонтальной каймой, с нупами, с бисером... Если начать от простого к сложному, с помощью книги вы станете асом и виртуозом. Независимо от вашего пола, возраста или навыков, каждый сможет связать свою собственную уникальную шаль!\r\n\r\nОб авторе:\r\nМарина Горштейн — замечательный российский мастер, дизайнер, вяжет уже много лет, более 5 лет обучает вязанию всех желающих. Работы Марины регулярно публикуются в СМИ, участвуют в творческих проектах и в выставках по всему миру. В 2021 году коллекции дизайнера были представлены на Детской неделе моды в Канаде.	4	6	2023	830	1779
16	5	8	Цветы в легендах и преданиях	Не все дороги устланы цветами, но без цветов нет жизни и нет истории. «Там, где вырождаются цветы, не может жить человек» (Гегель).\r\n\r\nНе все люди праведники, не все тпицы райские, но все цветы восхитительны и совершенны. Садовые, полевые, лесные, даже числящиеся сорняками,\r\n\r\n«С поезда выйдешь — как окликают!\r\n\r\nПо полю дрожь.\r\n\r\nПоле пришпорено васильками,\r\n\r\nкак ни уходишь — все не уйдешь» (А Вознесенский).\r\n\r\nНаверное, можно было бы обойтись без цветов, но они свидетельствуют о нашей свободе, «ибо доказывают, что мы не скованы по рукам и ногам будничными заботами» (Р. Тагор).\r\n\r\nНикогда с такой любовью и целомудрием люди не думают о Мире и Мироздании, как тогда, когда смотрят на цветы. Любой из них заставляет вспомнить о небе. Любой из них наполняет нас восхищением пред удивительным замыслом Творца. И в любом из них великая тайна, недоступная и самым выдающимся мудрецам. Тайна, рождающая предания и легенды...	6	7	2009	544	65800
22	8	14	Русский язык для старшеклассников и абитуриентов Кн.2 Ключи (3 изд) Великова	Специальный агент ФБР Мария Паркес, специалист по составлению психологических портретов, неутомимо идет по следу серийных убийц. Мария обладает даром медиума, каждую ночь она видит во сне убийства, точно передачи в прямом эфире, не имея возможности предотвратить ужасное действо. Благодаря своему дару она уже выследила несколько душегубов. На этот раз пропала помощница шерифа Рейчел, которая занималась расследованием исчезновения четырех молодых официанток. Следы Рейчел приводят Марию в лес, к развалинам старой церкви. То, что она увидела там, в подземелье, заставило ее похолодеть...	11	8	2016	168	19
17	6	9	Русская история	Книга в коллекционном переплёте, изготовленном из натуральной гладкой кожи, украшенном тончайшим тиснением в русском стиле. На предней сторонке изображен св. Георгий Победоносец, поражающий змия, на корешке использован рукописный шрифт. Книга отпечатана на белой бумаге с лёгкой текстурой. Более 150-ти редких графических иллюстраций в тексте.\r\nЦветные иллюстрации отпечатаны на специальных листах из высокобелой мелованной бумаги, вшитых в книгу.\r\n4 вида тиснения - золото, серебро, красный натуральный пигмент и рельефное тиснение.\r\nФорзацы из дизайнерской тонированной бумаги. Обрез окрашен в цвет переплёта, торшонирован и вызолочен вручную.\r\nЛента для закладывания страниц и каптал, скрепляющий верх и низ объемного тома, изготовлены из шелка. К книге прилагается красочный сертификат, подтверждающий уникальность издания, он вложен в каждый экземпляр и пронумерован вручную.	4	8	2021	896	31880
18	6	10	Спецслужбы России за 1000 лет	Любое государство только тогда может называться государством, когда оно способно обеспечить безопасность - свою и своих граждан - доступными ему методами. . .Книга, ставшая результатом продолжительного изучения архивных материалов, подробно рассказывает об истоках, формировании и развитии отечественных силовых, разведывательных и контртеррористических подразделений, о методах работы и практическом опыте спецслужб на различных этапах истории Российского государства.	7	9	2017	784	26401
19	7	12	Пушкин. Лермонтов. Современное прочтение классики	В книге кандидата филологических наук Е.А. Бурцевой "Пушкин. Лермонтов. Современное прочтения классики" собраны статьи о жизни и творчестве великих поэтов 1 половины XIX века, сыгравших ключевую роль в становлении большой русской литературы. Автор рассматривает как хрестоматийные, так и малоизвестные широкому кругу читателей произведения в новом ключе, избегая характерного для прошлых литературоведческих эпох вульгарного социологизма. Особенно пристально автор анализирует некоторые литературные произведения в сравнительно-сопоставительном и текстологическом аспекте, такие как драму А.С. Пушкина "Борис Годунов", произведение, которое сам поэт называл главным в своем творчестве, романтическую поэму М.Ю. Лермонтова "Демон" над которой Лермонтов работал с юности и в которую вложил все свои самые сокровенные представления о добре и зле. При этом проводятся параллели и говорится о влиянии Пушкина и Лермонтова на писателей и поэтов последующих эпох - от Ф.М. Достоевского до М.А. Булгакова.	9	8	2017	156	14581
20	6	13	АК-47. История создания и принятия на вооружение Советской армии: историческое издание	Автомат конструкции М. Т. Калашникова занимает особое место в истории стрелкового оружия мира. Он состоит на вооружении армии России и многих других стран мира уже более 70 лет. Несмотря на столь солидный срок службы, этот автомат и сейчас соответствует главным требованиям армии, а по безотказности остается непревзойденным до сих пор. Автомат Калашникова интересен огромной аудитории читателей, ему посвящено множество публикаций. В то же время за семь десятилетий боевого использования автомата Калашникова по-настоящему исчерпывающей истории его создания до сих пор не было написано, что не соответствует роли этого оружия в развитии отечественной оружейной школы. Настоящая книга призвана устранить это упущение. В книге описаны события начиная от раннего этапа творчества М. Т. Калашникова как конструктора-оружейника до включения его в конкурс на разработку автомата в 1946 г., запуска автомата АК-47 в серийное производство на Ижевских оружейных заводах в 1948-1948 гг. и его принятия на вооружение cоветской армии в 1949 г. Эти события освещены с учетом комплекса тактических, технических, экономических, военно-политических факторов и других событий, воздействовавших на разработку ручного автоматического оружия в СССР в начале-конце 1940-х гг. Книга насыщена изображениями опытных образцов оружия и другим документальным и иллюстративным материалом, раскрывающим суть и ход описываемых событий. В книге проведен технический анализ опытных автоматов М. Т. Калашникова и автоматов, разработанных другими конструкторами, приведены изображения их внешнего вида и внутреннего устройства. Часть опубликованных в книге образцов оружия представляется общественности впервые. Книга написана на основе уникальной коллекции опытного советского автоматического оружия, хранящейся в Военно-историческом музее артиллерии, инженерных войск и войск связи. Документальную основу материала книги составляют источники из архивных фондов Военно-исторического музея артиллерии, инженерных войск и войск связи, Центрального архива Министерства обороны РФ, других архивов и музеев РФ, а также из Архива Президента Республики Казахстан. Рекомендуем книгу всем читателям, интересующимся историей советского стрелкового оружия.	10	10	2021	600	12032
21	8	8	Контурные карты. География. 9 кл. /Универсальная линия	Контурные карты содержат необходимый набор карт по курсу географии соответствующего класса и могут быть использованы с любым УМК.	11	8	2017	16	11
23	9	8	Прописи. Математические каллиграфические прописи с развивающими заданиями. 6-7 лет	В пособии предложены задания, направленные на формирование навыков написания цифр у дошкольников и младших школьников. По этой тетради ребенок научится правильно и красиво писать цифры и математические элементы. Выполняя занимательные задания и графические упражнения в игровой форме, дошкольник научится считать в пределах десяти, писать цифры по клеточкам и точкам. В процессе выполнения разнообразных заданий развиваются внимание. Увлекательные задания, собранные в книжке, развивают мелкую моторику, внимание, память, логическое мышление - качества, которые помогут хорошо учиться в школе, расширяют кругозор и словарный запас.\r\nПредназначено дошкольникам и учащимся начальной школы; полезно родителям, которые хотят помочь своим детям подготовиться к школе.	12	11	2018	19	45
24	1	15	Белая Богиня	Анна полюбила Лиссабон с первого взгляда, хотя и потеряла в нем возлюбленного. Но ей некогда грустить о прошлом, ведь она — наследница древнего португальского рода. И теперь ей предстоит вступить во владение старинным особняком. Жаль, что из-за пандемии процесс затягивается.\r\nОднажды Анна заметила за собой слежку. А вскоре… очнулась в странном месте, похожем на Стоунхендж. И увидела странную процессию женщин в белых одеяниях.\r\nКто привез ее сюда и зачем? Чтобы ответить на эти вопросы, надо сначала выбраться из жуткого места…	13	12	2020	288	239
\.


--
-- TOC entry 3085 (class 0 OID 1301690)
-- Dependencies: 217
-- Data for Name: carts; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.carts (user_id, book_id, primary_id, cart_values) FROM stdin;
\.


--
-- TOC entry 3073 (class 0 OID 1244258)
-- Dependencies: 205
-- Data for Name: genres; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.genres (genre_id, genre_name) FROM stdin;
2	Фэнтези
1	Детективный роман. Триллер
4	Вязание. Валяние
5	Художественная литература. Фольклор
6	История. Общество
7	Литературоведение. Фольклористика
8	Образование
9	Дошкольное образование
\.


--
-- TOC entry 3075 (class 0 OID 1244321)
-- Dependencies: 207
-- Data for Name: publishers; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.publishers (publisher_id, publisher_name) FROM stdin;
1	АСТ
2	КОМИЛЬФО
3	БОМБОРА
4	ЭКСМО
5	Fanzon
6	ИЗДАТЕЛЬСКИЙ ДОМ "ЭКОНОМИЧЕСКА"
7	РИПОЛ-КЛАССИК
8	BLOOMSBURY
9	LAP LAMBERT ACADEMIC PUBLISHIN
10	АТЛАНТ
11	ПРОСВЕЩЕНИЕ
12	УЧИТЕЛЬ
13	БАУЭР МЕДИА
\.


--
-- TOC entry 3083 (class 0 OID 1293504)
-- Dependencies: 215
-- Data for Name: roles; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.roles (role_id, role_name, role_is_admin) FROM stdin;
1	Администратор	t
3	Пользователь	f
\.


--
-- TOC entry 3077 (class 0 OID 1252513)
-- Dependencies: 209
-- Data for Name: series; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.series (series_id, series_name) FROM stdin;
1	Сказания о магии Поднебесной
2	tyuiopoiuyteertyuioiiiiiiiiiiiiii
3	1231231212
5	123123123123
6	Подарочные издания. Сокровища русского рукоделия
7	РУССКАЯ КЛАССИЧЕСКАЯ БИБЛИОТЕКА "ЭКОНОМИКА И ДУХОВНОСТЬ"
8	Без серии
9	Золотая коллекция
10	ОРУЖЕЙНАЯ АКАДЕМИЯ
11	Дошкольный тренажер
12	ЛИТЕРАТУРНОЕ ПРИЛОЖЕНИЕ К ЖЕНСКИМ ЖУРНАЛАМ
\.


--
-- TOC entry 3079 (class 0 OID 1293473)
-- Dependencies: 211
-- Data for Name: users; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.users (user_id, user_login, user_password, user_register_date, role_id) FROM stdin;
1	admin	admin	2023-09-30 14:46:57.797922	1
2	test	test	2023-10-04 12:21:24.197097	3
3	test2	test	2023-11-17 14:33:47.240031	1
4	test3	test	2023-11-17 14:37:22.734188	3
6	123123	123123	2024-02-02 13:02:32.824017	3
\.


--
-- TOC entry 3081 (class 0 OID 1293485)
-- Dependencies: 213
-- Data for Name: users_books; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.users_books (ub_id, user_id, book_id, ub_add_date) FROM stdin;
2	1	1	2023-11-21 20:23:27.996091
3	1	6	2023-11-24 17:42:58.806824
6	1	7	2023-11-24 17:48:47.178263
9	1	5	2023-11-24 17:49:05.984353
11	1	8	2023-11-24 17:49:12.214326
12	1	3	2023-11-24 17:49:14.535901
15	2	12	2023-11-24 19:06:39.550127
16	1	15	2024-02-08 20:54:54.672475
17	1	8	2024-02-08 20:54:54.676232
18	1	14	2024-02-08 20:54:54.676814
19	1	2	2024-02-08 20:54:54.677337
20	1	3	2024-02-08 20:54:54.677908
21	1	14	2024-02-08 21:16:43.686865
22	1	8	2024-02-08 21:16:43.691821
23	1	6	2024-02-08 21:16:43.69235
24	1	6	2024-02-08 21:17:08.203655
25	1	5	2024-02-08 21:17:08.210228
26	1	14	2024-02-08 21:17:08.210923
27	1	14	2024-02-08 21:18:12.255071
28	1	15	2024-02-08 21:18:12.262062
29	1	1	2024-02-08 21:18:12.262685
30	1	15	2024-02-09 12:58:49.344401
31	1	8	2024-02-12 20:04:23.294153
32	1	6	2024-02-12 20:04:23.298989
33	1	15	2024-02-12 20:04:23.29944
34	1	2	2024-02-12 20:04:23.299797
35	1	14	2024-02-12 20:04:23.300263
36	1	1	2024-02-12 20:04:23.300617
37	1	3	2024-02-12 20:04:23.301149
38	1	16	2024-02-12 21:41:52.915794
39	1	22	2024-02-12 21:41:52.921853
40	1	17	2024-02-12 21:41:52.922401
41	1	18	2024-02-12 21:41:52.922873
42	1	19	2024-02-12 21:41:52.923243
43	1	20	2024-02-12 21:41:52.923651
44	1	21	2024-02-12 21:41:52.924095
45	1	23	2024-02-12 21:41:52.924545
46	1	24	2024-02-12 21:41:52.925015
\.


--
-- TOC entry 3093 (class 0 OID 0)
-- Dependencies: 202
-- Name: authors_author_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.authors_author_id_seq', 15, true);


--
-- TOC entry 3094 (class 0 OID 0)
-- Dependencies: 200
-- Name: books_book_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.books_book_id_seq', 24, true);


--
-- TOC entry 3095 (class 0 OID 0)
-- Dependencies: 216
-- Name: carts_primary_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.carts_primary_id_seq', 41, true);


--
-- TOC entry 3096 (class 0 OID 0)
-- Dependencies: 204
-- Name: genres_genre_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.genres_genre_id_seq', 9, true);


--
-- TOC entry 3097 (class 0 OID 0)
-- Dependencies: 206
-- Name: publishers_publisher_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.publishers_publisher_id_seq', 13, true);


--
-- TOC entry 3098 (class 0 OID 0)
-- Dependencies: 214
-- Name: roles_role_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.roles_role_id_seq', 3, true);


--
-- TOC entry 3099 (class 0 OID 0)
-- Dependencies: 208
-- Name: series_series_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.series_series_id_seq', 12, true);


--
-- TOC entry 3100 (class 0 OID 0)
-- Dependencies: 212
-- Name: users_books_ub_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.users_books_ub_id_seq', 46, true);


--
-- TOC entry 3101 (class 0 OID 0)
-- Dependencies: 210
-- Name: users_user_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.users_user_id_seq', 6, true);


--
-- TOC entry 2912 (class 2606 OID 1244255)
-- Name: authors authors_pk; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.authors
    ADD CONSTRAINT authors_pk PRIMARY KEY (author_id);


--
-- TOC entry 2910 (class 2606 OID 1244248)
-- Name: books books_pk; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.books
    ADD CONSTRAINT books_pk PRIMARY KEY (book_id);


--
-- TOC entry 2928 (class 2606 OID 1301694)
-- Name: carts carts_pk; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.carts
    ADD CONSTRAINT carts_pk PRIMARY KEY (primary_id);


--
-- TOC entry 2914 (class 2606 OID 1244262)
-- Name: genres genres_pk; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.genres
    ADD CONSTRAINT genres_pk PRIMARY KEY (genre_id);


--
-- TOC entry 2916 (class 2606 OID 1244328)
-- Name: publishers publishers_pk; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.publishers
    ADD CONSTRAINT publishers_pk PRIMARY KEY (publisher_id);


--
-- TOC entry 2926 (class 2606 OID 1293511)
-- Name: roles roles_pk; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.roles
    ADD CONSTRAINT roles_pk PRIMARY KEY (role_id);


--
-- TOC entry 2918 (class 2606 OID 1252520)
-- Name: series series_pk; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.series
    ADD CONSTRAINT series_pk PRIMARY KEY (series_id);


--
-- TOC entry 2924 (class 2606 OID 1293490)
-- Name: users_books users_books_pk; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.users_books
    ADD CONSTRAINT users_books_pk PRIMARY KEY (ub_id);


--
-- TOC entry 2920 (class 2606 OID 1293480)
-- Name: users users_pk; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.users
    ADD CONSTRAINT users_pk PRIMARY KEY (user_id);


--
-- TOC entry 2922 (class 2606 OID 1293482)
-- Name: users users_un; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.users
    ADD CONSTRAINT users_un UNIQUE (user_login);


--
-- TOC entry 2929 (class 2606 OID 1244272)
-- Name: books books_fk; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.books
    ADD CONSTRAINT books_fk FOREIGN KEY (genre_id) REFERENCES public.genres(genre_id) ON UPDATE CASCADE ON DELETE CASCADE;


--
-- TOC entry 2930 (class 2606 OID 1244282)
-- Name: books books_fk1; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.books
    ADD CONSTRAINT books_fk1 FOREIGN KEY (author_id) REFERENCES public.authors(author_id) ON UPDATE CASCADE ON DELETE CASCADE;


--
-- TOC entry 2931 (class 2606 OID 1244329)
-- Name: books books_fk2; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.books
    ADD CONSTRAINT books_fk2 FOREIGN KEY (publisher_id) REFERENCES public.publishers(publisher_id) ON UPDATE CASCADE ON DELETE CASCADE;


--
-- TOC entry 2932 (class 2606 OID 1252521)
-- Name: books books_fk3; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.books
    ADD CONSTRAINT books_fk3 FOREIGN KEY (series_id) REFERENCES public.series(series_id) ON UPDATE CASCADE ON DELETE CASCADE;


--
-- TOC entry 2936 (class 2606 OID 1301695)
-- Name: carts carts_fk; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.carts
    ADD CONSTRAINT carts_fk FOREIGN KEY (user_id) REFERENCES public.users(user_id) ON UPDATE CASCADE ON DELETE CASCADE;


--
-- TOC entry 2937 (class 2606 OID 1301700)
-- Name: carts carts_fk_1; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.carts
    ADD CONSTRAINT carts_fk_1 FOREIGN KEY (book_id) REFERENCES public.books(book_id) ON UPDATE CASCADE ON DELETE CASCADE;


--
-- TOC entry 2934 (class 2606 OID 1293491)
-- Name: users_books users_books_fk; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.users_books
    ADD CONSTRAINT users_books_fk FOREIGN KEY (book_id) REFERENCES public.books(book_id) ON UPDATE CASCADE ON DELETE CASCADE;


--
-- TOC entry 2935 (class 2606 OID 1293496)
-- Name: users_books users_books_fk_1; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.users_books
    ADD CONSTRAINT users_books_fk_1 FOREIGN KEY (user_id) REFERENCES public.users(user_id) ON UPDATE CASCADE ON DELETE CASCADE;


--
-- TOC entry 2933 (class 2606 OID 1293512)
-- Name: users users_fk; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.users
    ADD CONSTRAINT users_fk FOREIGN KEY (role_id) REFERENCES public.roles(role_id) ON UPDATE CASCADE ON DELETE CASCADE;


-- Completed on 2024-02-12 21:43:24

--
-- PostgreSQL database dump complete
--

