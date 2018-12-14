-- phpMyAdmin SQL Dump
-- version 4.5.4.1deb2ubuntu2
-- http://www.phpmyadmin.net
--
-- Gép: localhost
-- Létrehozás ideje: 2017. Jan 26. 13:44
-- Kiszolgáló verziója: 5.7.17-0ubuntu0.16.04.1
-- PHP verzió: 7.0.8-0ubuntu0.16.04.3

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Adatbázis: `gycsaba`
--

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `pfutar`
--

CREATE TABLE `pfutar` (
  `fazon` int(3) NOT NULL DEFAULT '0',
  `fnev` varchar(25) COLLATE latin2_hungarian_ci NOT NULL DEFAULT '',
  `ftel` varchar(12) COLLATE latin2_hungarian_ci NOT NULL DEFAULT ''
) ENGINE=MyISAM DEFAULT CHARSET=latin2 COLLATE=latin2_hungarian_ci;

--
-- A tábla adatainak kiíratása `pfutar`
--

INSERT INTO `pfutar` (`fazon`, `fnev`, `ftel`) VALUES
(1, 'Hurrikán', '123456'),
(2, 'Gyalogkakukk', '666666'),
(3, 'Gömbvillám', '888888'),
(4, 'Szélvész', '258369'),
(5, 'Imperial', '987654');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `ppizza`
--

CREATE TABLE `ppizza` (
  `pazon` int(3) NOT NULL DEFAULT '0',
  `pnev` varchar(15) COLLATE latin2_hungarian_ci NOT NULL DEFAULT '',
  `par` int(4) NOT NULL DEFAULT '0'
) ENGINE=MyISAM DEFAULT CHARSET=latin2 COLLATE=latin2_hungarian_ci;

--
-- A tábla adatainak kiíratása `ppizza`
--

INSERT INTO `ppizza` (`pazon`, `pnev`, `par`) VALUES
(1, 'Capricciosa', 900),
(2, 'Frutti di Mare', 1100),
(3, 'Hawaii', 780),
(4, 'Vesuvio', 890),
(5, 'Sorrento', 990);

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `prendeles`
--

CREATE TABLE `prendeles` (
  `razon` int(8) NOT NULL DEFAULT '0',
  `vazon` int(6) NOT NULL DEFAULT '0',
  `fazon` int(3) NOT NULL DEFAULT '0',
  `datum` date NOT NULL DEFAULT '2017-01-01',
  `ido` float NOT NULL DEFAULT '0'
) ENGINE=MyISAM DEFAULT CHARSET=latin2 COLLATE=latin2_hungarian_ci;

--
-- A tábla adatainak kiíratása `prendeles`
--

INSERT INTO `prendeles` (`razon`, `vazon`, `fazon`, `datum`, `ido`) VALUES
(1, 4, 2, '2010-10-01', 13.15),
(2, 7, 2, '2010-10-01', 14.17),
(3, 1, 1, '2010-10-02', 11.07),
(4, 5, 2, '2010-10-02', 14.55),
(5, 2, 3, '2010-10-02', 15.27),
(6, 4, 2, '2010-10-03', 15.58),
(7, 6, 2, '2010-10-04', 11.44),
(8, 7, 4, '2010-10-04', 12.11),
(9, 1, 5, '2010-10-04', 14.33),
(10, 3, 5, '2010-10-04', 18.04),
(11, 2, 1, '2010-10-05', 16.38),
(12, 5, 2, '2010-10-05', 17.02),
(13, 6, 2, '2010-10-06', 12.17),
(14, 4, 3, '2010-10-06', 13.21),
(15, 1, 4, '2010-10-06', 15.05),
(16, 2, 5, '2010-10-06', 15.59),
(17, 7, 2, '2010-10-06', 18.44),
(18, 3, 2, '2010-10-07', 12.01),
(19, 4, 5, '2010-10-07', 13.44),
(20, 1, 1, '2010-10-07', 17.25),
(21, 5, 3, '2010-10-08', 14.29);

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `ptetel`
--

CREATE TABLE `ptetel` (
  `razon` int(8) NOT NULL DEFAULT '0',
  `pazon` int(3) NOT NULL DEFAULT '0',
  `db` int(3) NOT NULL DEFAULT '0'
) ENGINE=MyISAM DEFAULT CHARSET=latin2 COLLATE=latin2_hungarian_ci;

--
-- A tábla adatainak kiíratása `ptetel`
--

INSERT INTO `ptetel` (`razon`, `pazon`, `db`) VALUES
(1, 1, 2),
(1, 4, 3),
(2, 2, 1),
(3, 1, 2),
(4, 1, 1),
(4, 4, 1),
(5, 2, 4),
(6, 1, 1),
(6, 4, 1),
(6, 5, 1),
(7, 5, 5),
(8, 4, 3),
(9, 2, 1),
(10, 1, 1),
(10, 4, 1),
(11, 1, 1),
(12, 2, 2),
(12, 4, 2),
(13, 4, 1),
(13, 5, 1),
(13, 2, 1),
(14, 2, 2),
(15, 1, 1),
(16, 2, 1),
(16, 4, 1),
(16, 5, 1),
(17, 1, 2),
(17, 2, 3),
(18, 1, 4),
(18, 5, 1),
(19, 1, 1),
(19, 2, 1),
(19, 4, 1),
(19, 5, 1),
(20, 5, 3),
(21, 2, 2),
(21, 4, 1);

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `pvevo`
--

CREATE TABLE `pvevo` (
  `vazon` int(6) NOT NULL DEFAULT '0',
  `vnev` varchar(30) COLLATE latin2_hungarian_ci NOT NULL DEFAULT '',
  `vcim` varchar(30) COLLATE latin2_hungarian_ci NOT NULL DEFAULT ''
) ENGINE=MyISAM DEFAULT CHARSET=latin2 COLLATE=latin2_hungarian_ci;

--
-- A tábla adatainak kiíratása `pvevo`
--

INSERT INTO `pvevo` (`vazon`, `vnev`, `vcim`) VALUES
(1, 'Hapci', ''),
(2, 'Vidor', ''),
(3, 'Tudor', ''),
(4, 'Kuka', ''),
(5, 'Szende', ''),
(6, 'Szundi', ''),
(7, 'Morgó', '');

--
-- Indexek a kiírt táblákhoz
--

--
-- A tábla indexei `pfutar`
--
ALTER TABLE `pfutar`
  ADD PRIMARY KEY (`fazon`);

--
-- A tábla indexei `ppizza`
--
ALTER TABLE `ppizza`
  ADD PRIMARY KEY (`pazon`);

--
-- A tábla indexei `prendeles`
--
ALTER TABLE `prendeles`
  ADD PRIMARY KEY (`razon`);

--
-- A tábla indexei `pvevo`
--
ALTER TABLE `pvevo`
  ADD PRIMARY KEY (`vazon`);

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
