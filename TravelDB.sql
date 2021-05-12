
CREATE TABLE public.transporttype (
    id bigint NOT NULL,
    name text NOT NULL
);


ALTER TABLE public.transporttype OWNER TO postgres;

--
-- Name: TransportType_Id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

ALTER TABLE public.transporttype ALTER COLUMN id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public."TransportType_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- Name: attraction; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.attraction (
    id bigint NOT NULL,
    name character varying NOT NULL,
    description character varying,
    rating double precision,
    cityid bigint
);


ALTER TABLE public.attraction OWNER TO postgres;

--
-- Name: city; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.city (
    id bigint NOT NULL,
    name character varying NOT NULL,
    description text,
    totalvisits bigint,
    rating double precision,
    countryid bigint
);


ALTER TABLE public.city OWNER TO postgres;

--
-- Name: country; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.country (
    id bigint NOT NULL,
    name text,
    description text
);


ALTER TABLE public.country OWNER TO postgres;

--
-- Name: tour; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.tour (
    id uuid NOT NULL,
    cityid bigint NOT NULL
);


ALTER TABLE public.tour OWNER TO postgres;

--
-- Name: transportcompany; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.transportcompany (
    id bigint NOT NULL,
    name text NOT NULL,
    description text,
    cityid bigint NOT NULL,
    totalvisits bigint,
    rating double precision,
    transporttypeid bigint NOT NULL
);


ALTER TABLE public.transportcompany OWNER TO postgres;

--
-- Name: transportoffer; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.transportoffer (
    id uuid NOT NULL,
    transportcompanyid bigint NOT NULL,
    cityid bigint NOT NULL,
    totalreservation bigint NOT NULL,
    currentreserved bigint,
    startdate date,
    finishdate date,
    price double precision
);


ALTER TABLE public.transportoffer OWNER TO postgres;

--
-- Name: attraction Attraction_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.attraction
    ADD CONSTRAINT "Attraction_pkey" PRIMARY KEY (id);


--
-- Name: city City_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.city
    ADD CONSTRAINT "City_pkey" PRIMARY KEY (id);


--
-- Name: transportoffer PK_TOfferId; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.transportoffer
    ADD CONSTRAINT "PK_TOfferId" PRIMARY KEY (id);


--
-- Name: tour Tour_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.tour
    ADD CONSTRAINT "Tour_pkey" PRIMARY KEY (id);


--
-- Name: transportcompany TransportCompany_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.transportcompany
    ADD CONSTRAINT "TransportCompany_pkey" PRIMARY KEY (id);


--
-- Name: transporttype TransportType_ID; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.transporttype
    ADD CONSTRAINT "TransportType_ID" PRIMARY KEY (id);


--
-- Name: country country_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.country
    ADD CONSTRAINT country_pkey PRIMARY KEY (id);


--
-- Name: transportcompany FK_TCompany_CityId; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.transportcompany
    ADD CONSTRAINT "FK_TCompany_CityId" FOREIGN KEY (cityid) REFERENCES public.city(id) NOT VALID;


--
-- Name: transportcompany FK_TCompany_TtypeId; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.transportcompany
    ADD CONSTRAINT "FK_TCompany_TtypeId" FOREIGN KEY (transporttypeid) REFERENCES public.transporttype(id) NOT VALID;


--
-- Name: transportoffer FK_TOffer_CityId; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.transportoffer
    ADD CONSTRAINT "FK_TOffer_CityId" FOREIGN KEY (cityid) REFERENCES public.city(id);


--
-- Name: transportoffer FK_TOffer_TCompanyId; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.transportoffer
    ADD CONSTRAINT "FK_TOffer_TCompanyId" FOREIGN KEY (transportcompanyid) REFERENCES public.transportcompany(id);


--
-- Name: attraction FKcity_AttractionId; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.attraction
    ADD CONSTRAINT "FKcity_AttractionId" FOREIGN KEY (cityid) REFERENCES public.city(id);


--
-- Name: tour Fk_Tour_CityId; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.tour
    ADD CONSTRAINT "Fk_Tour_CityId" FOREIGN KEY (cityid) REFERENCES public.city(id);


--
-- Name: city fk_cityid_countryid; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.city
    ADD CONSTRAINT fk_cityid_countryid FOREIGN KEY (countryid) REFERENCES public.country(id) NOT VALID;


--
-- PostgreSQL database dump complete
--

