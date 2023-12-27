import React from "react";
import moment from 'moment'
import styled from 'styled-components'
import headerStyles from "../styles/header.module.scss";
// We can all destructure the class name
const { header, headerWrapper } = headerStyles;
const Title = styled.h1`
  font-size: 70px;
  font-weight: 300;
`
const SubTitle = styled.h2`
  background-color: #61dbfb;
  padding: 25;
  padding: 10px;
  margin: 0;
`

const Header = () => (
  <header className={header}>
    <div className={headerWrapper}>
      <Title>
        <h1>30 Days Of React</h1>
        <SubTitle>
          <h2>Getting Started React</h2>
        </SubTitle>
        <h3>JavaScript Library</h3>
        <p>Instructor: Asabeneh Yetayeh</p>
        <small>{moment(new Date()).format("YYYY-MM-DD")}</small>
      </Title>
    </div>
  </header>
);
export default Header;
