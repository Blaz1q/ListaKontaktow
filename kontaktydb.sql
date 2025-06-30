-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Cze 30, 2025 at 02:44 PM
-- Wersja serwera: 10.4.32-MariaDB
-- Wersja PHP: 8.0.30

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `kontaktydb`
--

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `kontakty`
--

CREATE TABLE `kontakty` (
  `Imie` varchar(50) NOT NULL,
  `Nazwisko` varchar(50) NOT NULL,
  `Email` varchar(100) NOT NULL,
  `Haslo` varchar(255) NOT NULL,
  `KategoriaId` int(11) NOT NULL,
  `Podkategoria` varchar(50) DEFAULT NULL,
  `Telefon` varchar(20) DEFAULT NULL,
  `DataUrodzenia` date DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `kontakty`
--

INSERT INTO `kontakty` (`Imie`, `Nazwisko`, `Email`, `Haslo`, `KategoriaId`, `Podkategoria`, `Telefon`, `DataUrodzenia`) VALUES
('Jan', 'Kowalski', 'jankowalski@gmail.com', 'Haslo123.', 3, 'Brat', '123456789', '1990-06-18'),
('Jan', 'Szymon', 'janszymon@gmail.com', 'Haslo123.', 3, 'Mąż', '123421124', '2000-02-02'),
('Karol', 'Koralowy', 'koralowykarol@gmail.com', 'Haslo123.', 2, 'Klient', '321321321', '2000-02-18'),
('Mały', 'Jan', 'malyjan@gmail.com', 'Haslo123.', 3, 'Dziecko', '123123123', '2022-02-22'),
('Mały', 'Kowalski', 'malykowalski@gmail.com', 'Haslo123.', 3, 'Ksiądz', '333222111', '1990-04-02'),
('Tosia', 'Pies', 'PiesTosia@gmail.com', 'JstemPsem12', 3, NULL, '124526373', '2004-04-04'),
('Szczery', 'Przemek', 'szczeryprzemek23@onet.com', 'Haslo123.', 2, 'Klient', '123123123', '2000-01-10');

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `slownikkategorii`
--

CREATE TABLE `slownikkategorii` (
  `id` int(11) NOT NULL,
  `nazwa` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `slownikkategorii`
--

INSERT INTO `slownikkategorii` (`id`, `nazwa`) VALUES
(1, 'Prywatny'),
(2, 'Służbowy'),
(3, 'Inny');

--
-- Indeksy dla zrzutów tabel
--

--
-- Indeksy dla tabeli `kontakty`
--
ALTER TABLE `kontakty`
  ADD PRIMARY KEY (`Email`);

--
-- Indeksy dla tabeli `slownikkategorii`
--
ALTER TABLE `slownikkategorii`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `slownikkategorii`
--
ALTER TABLE `slownikkategorii`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
