-- phpMyAdmin SQL Dump
-- version 4.6.4
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: 2019-04-09 08:03:07
-- 服务器版本： 5.7.14
-- PHP Version: 5.6.25

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `db`
--

-- --------------------------------------------------------

--
-- 表的结构 `project`
--

CREATE TABLE `project` (
  `Id` int(13) NOT NULL,
  `项目名称` varchar(64) COLLATE utf8_bin NOT NULL,
  `工令` varchar(32) COLLATE utf8_bin NOT NULL,
  `合同号` varchar(64) COLLATE utf8_bin NOT NULL,
  `买方名称` varchar(64) COLLATE utf8_bin NOT NULL,
  `金额` decimal(10,0) NOT NULL,
  `签订日期` varchar(32) COLLATE utf8_bin NOT NULL,
  `交货日期` varchar(32) COLLATE utf8_bin NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

--
-- 转存表中的数据 `project`
--

INSERT INTO `project` (`Id`, `项目名称`, `工令`, `合同号`, `买方名称`, `金额`, `签订日期`, `交货日期`) VALUES
(1, '逆变一体机', '319002', 'N19-SA02-PV008.002', '东芝三菱电机工业系统（中国）有限公司', '5914400', '2019-03-27', '');

-- --------------------------------------------------------

--
-- 表的结构 `users`
--

CREATE TABLE `users` (
  `Id` int(10) NOT NULL,
  `Name` varchar(32) COLLATE utf8_bin NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

--
-- 转存表中的数据 `users`
--

INSERT INTO `users` (`Id`, `Name`) VALUES
(1, 'aa'),
(2, 'aa');

-- --------------------------------------------------------

--
-- 表的结构 `项目`
--

CREATE TABLE `项目` (
  `Id` int(13) NOT NULL,
  `项目名称` varchar(64) COLLATE utf8_bin NOT NULL,
  `工令` varchar(32) COLLATE utf8_bin NOT NULL,
  `合同号` varchar(64) COLLATE utf8_bin NOT NULL,
  `买方名称` varchar(64) COLLATE utf8_bin NOT NULL,
  `金额` decimal(10,0) NOT NULL,
  `签订日期` varchar(32) COLLATE utf8_bin NOT NULL,
  `交货日期` varchar(32) COLLATE utf8_bin NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

--
-- 转存表中的数据 `项目`
--

INSERT INTO `项目` (`Id`, `项目名称`, `工令`, `合同号`, `买方名称`, `金额`, `签订日期`, `交货日期`) VALUES
(1, '逆变一体机', '319002', 'N19-SA02-PV008.002', '东芝三菱电机工业系统（中国）有限公司', '5914400', '2019-03-27', '');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `project`
--
ALTER TABLE `project`
  ADD PRIMARY KEY (`Id`),
  ADD UNIQUE KEY `Id` (`Id`);

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`Id`),
  ADD UNIQUE KEY `Id` (`Id`);

--
-- Indexes for table `项目`
--
ALTER TABLE `项目`
  ADD PRIMARY KEY (`Id`),
  ADD UNIQUE KEY `Id` (`Id`);

--
-- 在导出的表使用AUTO_INCREMENT
--

--
-- 使用表AUTO_INCREMENT `project`
--
ALTER TABLE `project`
  MODIFY `Id` int(13) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;
--
-- 使用表AUTO_INCREMENT `users`
--
ALTER TABLE `users`
  MODIFY `Id` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;
--
-- 使用表AUTO_INCREMENT `项目`
--
ALTER TABLE `项目`
  MODIFY `Id` int(13) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
