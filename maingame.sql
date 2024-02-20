-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1
-- Létrehozás ideje: 2024. Feb 20. 11:17
-- Kiszolgáló verziója: 10.4.28-MariaDB
-- PHP verzió: 8.2.4

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Adatbázis: `maingame`
--
CREATE DATABASE IF NOT EXISTS `maingame` DEFAULT CHARACTER SET utf8 COLLATE utf8_hungarian_ci;
USE `maingame`;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `players`
--

CREATE TABLE `players` (
  `id` int(10) NOT NULL,
  `jatekosnev` varchar(16) NOT NULL,
  `jatekosjelszo` varchar(100) NOT NULL,
  `salt` varchar(50) NOT NULL,
  `regisztralt` datetime NOT NULL DEFAULT current_timestamp(),
  `pontszam` int(10) NOT NULL DEFAULT 0,
  `halalokszama` int(10) NOT NULL DEFAULT 0,
  `Levels` int(10) NOT NULL DEFAULT 1,
  `skin` int(10) NOT NULL DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- A tábla adatainak kiíratása `players`
--

INSERT INTO `players` (`id`, `jatekosnev`, `jatekosjelszo`, `salt`, `regisztralt`, `pontszam`, `halalokszama`, `Levels`, `skin`) VALUES
(1, 'admin', '$5$rounds=5000$steamedhamsadmin$Hjy7l7w6xSvQ0XC8tg73p04ohaszWmH4DwDZ/7Vy9p4', '$5$rounds=5000$steamedhamsadmin$', '2024-02-20 10:26:23', 50, 0, 1, 3),
(2, 'asd', '$5$rounds=5000$steamedhamsasd$8l9Be1en.Q4Wi5/2OjLhdF1KuXICTlJmk/WwoVRG5E.', '$5$rounds=5000$steamedhamsasd$', '2024-02-20 11:11:55', 0, 0, 1, 0);

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `stats`
--

CREATE TABLE `stats` (
  `playerid` int(10) NOT NULL,
  `termekid` int(10) NOT NULL,
  `statusz` tinyint(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- A tábla adatainak kiíratása `stats`
--

INSERT INTO `stats` (`playerid`, `termekid`, `statusz`) VALUES
(1, 1, 1);

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `termek`
--

CREATE TABLE `termek` (
  `termekid` int(10) NOT NULL,
  `termeknev` varchar(50) NOT NULL,
  `ar` int(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- A tábla adatainak kiíratása `termek`
--

INSERT INTO `termek` (`termekid`, `termeknev`, `ar`) VALUES
(1, 'beka_skin', 20),
(2, 'pinkman_skin', 50);

--
-- Indexek a kiírt táblákhoz
--

--
-- A tábla indexei `players`
--
ALTER TABLE `players`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `jatekosnev` (`jatekosnev`);

--
-- A tábla indexei `stats`
--
ALTER TABLE `stats`
  ADD UNIQUE KEY `playerid` (`playerid`),
  ADD UNIQUE KEY `termekid` (`termekid`);

--
-- A tábla indexei `termek`
--
ALTER TABLE `termek`
  ADD PRIMARY KEY (`termekid`);

--
-- A kiírt táblák AUTO_INCREMENT értéke
--

--
-- AUTO_INCREMENT a táblához `players`
--
ALTER TABLE `players`
  MODIFY `id` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT a táblához `termek`
--
ALTER TABLE `termek`
  MODIFY `termekid` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- Megkötések a kiírt táblákhoz
--

--
-- Megkötések a táblához `stats`
--
ALTER TABLE `stats`
  ADD CONSTRAINT `stats_ibfk_1` FOREIGN KEY (`playerid`) REFERENCES `players` (`id`),
  ADD CONSTRAINT `stats_ibfk_2` FOREIGN KEY (`termekid`) REFERENCES `termek` (`termekid`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
