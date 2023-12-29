// import logo from './logo.svg';
import Section from './Section';
import Heading from './Heading'
import './App.css';

function App() {
  return (
    <div className="App">
      <header className="App-header">
        <Section>
          <Heading level={1}>title</Heading>
          <Section>
            <Heading level={2}>Heading</Heading>
            <Heading level={2}>Heading</Heading>
            <Heading level={2}>Heading</Heading>
            <Section>
              <Heading level={3}>Sub-heading</Heading>
              <Heading level={3}>Sub-heading</Heading>
              <Heading level={3}>Sub-heading</Heading>
              <Section>
                <Heading level={4}>Sub-sub-heading</Heading>
                <Heading level={4}>Sub-sub-heading</Heading>
                <Heading level={4}>Sub-sub-heading</Heading>
              </Section>
            </Section>
          </Section>
        </Section>
      </header>
    </div>
  );
}

export default App;
