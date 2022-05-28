-- phpMyAdmin SQL Dump
-- version 5.1.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: May 25, 2022 at 12:30 PM
-- Server version: 10.4.19-MariaDB
-- PHP Version: 8.0.6

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `whatsapp`
--

-- --------------------------------------------------------

--
-- Table structure for table `customers`
--

CREATE TABLE `customers` (
  `customer_nr` int(11) NOT NULL,
  `balance` int(11) NOT NULL,
  `telephone_nr` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `print_orders`
--

CREATE TABLE `print_orders` (
  `reference_nr` int(11) NOT NULL,
  `customer_nr` int(11) NOT NULL,
  `nr_copies` int(11) NOT NULL,
  `chat_ref_id` varchar(255) NOT NULL,
  `status` enum('printable','error','printed','') NOT NULL,
  `order_made_time` timestamp NULL DEFAULT NULL,
  `order_finished_time` timestamp NULL DEFAULT NULL,
  `file_location` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `customers`
--
ALTER TABLE `customers`
  ADD PRIMARY KEY (`customer_nr`);

--
-- Indexes for table `print_orders`
--
ALTER TABLE `print_orders`
  ADD PRIMARY KEY (`reference_nr`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `customers`
--
ALTER TABLE `customers`
  MODIFY `customer_nr` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `print_orders`
--
ALTER TABLE `print_orders`
  MODIFY `reference_nr` int(11) NOT NULL AUTO_INCREMENT;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
